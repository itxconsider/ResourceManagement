using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Models.Request;
using Web.Client.Managers;

namespace Web.Client.Pages
{
    public partial class DepartmentModal
    {
        [Inject] private IDepartmentManager DepartmentManager { get; set; }
        [Parameter] public DepartmentRequest DepartmentModel { get; set; } = new ();
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private FluentValidationValidator _fluentValidationValidator;
       // private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

        public void Cancel()
        {
            MudDialog.Cancel();
        }
        private async Task SaveAsync()
        {
            var response = await DepartmentManager.SaveAsync(DepartmentModel);
            if (response.IsSuccess)
            {
               // _snackBar.Add(response.Messages[0], Severity.Success);
               // await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                   // _snackBar.Add(message, Severity.Error);
                }
            }
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    HubConnection = HubConnection.TryInitialize(_navigationManager);
        //    if (HubConnection.State == HubConnectionState.Disconnected)
        //    {
        //        await HubConnection.StartAsync();
        //    }
        //}
    }
}
