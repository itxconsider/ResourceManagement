using Microsoft.AspNetCore.Components;
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
            var response = await DepartmentManager.ge(request);
            if (response.Succeeded)
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

    }
}
