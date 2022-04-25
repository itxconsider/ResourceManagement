namespace Shared.Models.Request
{
    public class GetAllPagedDepartmentRequest : PagedRequest
    {
        public string SearchString { get; set; }
    }
}
