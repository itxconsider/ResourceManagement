namespace Web.Client.Routes
{
    public static class PositionEndpoint
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/position/export";
        public static string GetAll = "api/positions";
        public static string Delete = "api/position";
        public static string Save = "api/resource";
        public static string GetCount = "api/position/count";
        public static string? GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/positions?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                url = orderBy.Aggregate(url, (current, orderByPart) => current + $"{orderByPart},");
                url = url[..^1]; // loose training ,
            }
            return url;
        }
    }
}
