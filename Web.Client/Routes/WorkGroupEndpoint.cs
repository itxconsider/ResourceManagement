namespace Web.Client.Routes
{
    public static class WorkGroupEndpoint
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/work-group/export";
        public static string GetAll = "api/work-groups";
        public static string Delete = "api/work-group";
        public static string Save = "api/work-group";
        public static string GetCount = "api/work-group/count";
        public static string? GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/work-groups?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                url = orderBy.Aggregate(url, (current, orderByPart) => current + $"{orderByPart},");
                url = url[..^1]; // loose training ,
            }
            return url;
        }
    }
}
