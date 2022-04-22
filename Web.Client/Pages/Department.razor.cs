using Microsoft.AspNetCore.Components;
using MudBlazor;
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

    }
}
