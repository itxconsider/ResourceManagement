namespace Web.Client.Routes
{
    public static class ResponsibilityEndpoint
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/responsibility/export";
        public static string GetAll = "api/responsibilities";
        public static string Delete = "api/responsibility";
        public static string Save = "api/responsibility";
        public static string GetCount = "api/responsibility/count";
        public static string? GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/responsibilities?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                url = orderBy.Aggregate(url, (current, orderByPart) => current + $"{orderByPart},");
                url = url[..^1]; // loose training ,
            }
            return url;
        }
    }
}
