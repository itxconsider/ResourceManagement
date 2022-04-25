namespace Web.Client.Routes
{
    public static class ResourceEndpoint
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/resource/export";
        public static string GetAll = "api/resources";
        public static string Delete = "api/resource";
        public static string Save = "api/resource";
        public static string GetCount = "api/resource/count";
        public static string? GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/resources?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                url = orderBy.Aggregate(url, (current, orderByPart) => current + $"{orderByPart},");
                url = url[..^1]; // loose training ,
            }
            return url;
        }
    }
}
