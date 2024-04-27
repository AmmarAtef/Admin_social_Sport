namespace Api.Dto.CountryDto
{
    public class Error
    {
        public string Id { get; set; }
        public string Code { get; set; } = "";
        public string Message { get; set; } = "";
        public object? ErrorData { get; set; }
        public string? ExceptionDetails { get; set; }
    }
}

