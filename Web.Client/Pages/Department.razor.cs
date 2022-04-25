using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using Shared.Models.Request;
using Shared.Models.Response;
using System.Security.Claims;
using Web.Client.Managers;

namespace Web.Client.Pages
{
    public partial class Department
    {
        [Inject] private IDepartmentManager DepartmentManager { get; set; }
        private IEnumerable<DepartmentResponse> _pagedData;
        private MudTable<DepartmentResponse> _table;
        private int _totalItems;
        private int _currentPage;
        private string _searchString = "";
        private bool _dense = true;
        private bool _striped = true;
        private bool _bordered = false;

        private ClaimsPrincipal _currentUser;
        private bool _canCreate;
        private bool _canEdit;
        private bool _canDelete;
        private bool _canExport;
        private bool _canSearch;
        private bool _loaded;

        private async Task<TableData<DepartmentResponse>> ServerReload(TableState state)
        {
            if (!string.IsNullOrWhiteSpace(_searchString))
            {
                state.Page = 0;
            }
            await LoadData(state.Page, state.PageSize, state);
            return new TableData<DepartmentResponse> { TotalItems = _totalItems, Items = _pagedData };
        }
        private async Task LoadData(int pageNumber, int pageSize, TableState state)
        {
            string[] orderings = null;
            if (!string.IsNullOrEmpty(state.SortLabel))
            {
                orderings = state.SortDirection != SortDirection.None ? new[] { $"{state.SortLabel} {state.SortDirection}" } : new[] { $"{state.SortLabel}" };
            }

            var request = new GetAllPagedDepartmentRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = _searchString, Orderby = orderings };
            var response = await DepartmentManager.GetAllDepartmentsAsync(request);
            if (response.IsSuccess)
            {
                _totalItems = response.TotalCount;
                _currentPage = response.CurrentPage;
                _pagedData = response.Data;
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task InvokeModal(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                var customer = _pagedData.FirstOrDefault(c => c.Id == id);
                if (customer != null)
                {
                    parameters.Add(nameof(CustomerModal.AddUpdateCustomerModel), new AddUpdateCustomerCommand
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Description = customer.Description,
                        Address = customer.Address,
                        NationalId = customer.NationalId,
                        Gender = customer.Gender,
                        AccountName = customer.AccountName,
                        AccountNumber = customer.AccountNumber,
                        BankName = customer.BankName,
                        DateOfBirth = customer.DateOfBirth
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<CustomerModal>(id == 0 ? _localizer["Create"] : _localizer["Edit"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }

            private void OnSearch(string text)
        {
            _searchString = text;
            _table.ReloadServerData();
        }
        private async Task ExportToExcel()
        {
            var response = await DepartmentManager.ExportToExcelAsync(_searchString);
            if (response.IsSuccess)
            {
                await _jsRuntime.InvokeVoidAsync("Download", new
                {
                    ByteArray = response.Data,
                    //FileName = $"{nameof(Customers).ToLower()}_{DateTime.Now:ddMMyyyyHHmmss}.xlsx",
                    //MimeType = ApplicationConstants.MimeTypes.OpenXml
                });
                _snackBar.Add(string.IsNullOrWhiteSpace(_searchString)
                    ? _localizer["Products exported"]
                    : _localizer["Filtered Products exported"], Severity.Success);
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }

        }

        private async Task Delete(Guid id)
        {
            string deleteContent = _localizer["Delete Content"];
            var parameters = new DialogParameters
            {
                {nameof(Shared.Dialogs.DeleteConfirmation.ContentText), string.Format(deleteContent, id)}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>(_localizer["Delete"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await DepartmentManager.DeleteAsync(id);
                if (response.IsSuccess)
                {
                    OnSearch("");
                  //  await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                    _snackBar.Add(response.Messages[0], Severity.Success);
                }
                else
                {
                    OnSearch("");
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
            }
        }
    }
}
