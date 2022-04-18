using ResourceManagement.Models;
using ResourceManagement.Specifications.Base;

namespace ResourceManagement.Specifications.Catalog
{
    public class DepartmentFilterSpecification : ModelSpecification<Department>
    {
        public DepartmentFilterSpecification(string? searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.Name != null && (p.Name.Contains(searchString));
            }
            else
            {
                Criteria = p => p.Name != null;
            }
        }
    }
}