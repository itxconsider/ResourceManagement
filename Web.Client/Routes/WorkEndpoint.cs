namespace Web.Client.Routes
{
    public static class WorkEndpoint
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/work/export";
        public static string GetAll = "api/works";
        public static string Delete = "api/work";
        public static string Save = "api/work";
        public static string GetCount = "api/work/count";
        public static string? GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/works?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                url = orderBy.Aggregate(url, (current, orderByPart) => current + $"{orderByPart},");
                url = url[..^1]; // loose training ,
            }
            return url;
        }
    }
}
