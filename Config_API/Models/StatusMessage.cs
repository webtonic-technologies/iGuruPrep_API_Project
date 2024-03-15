namespace Config_API.Models
{
    public class StatusMessage
    {
        public int StatusId { get; set; }
        public int? StatusCode { get; set; }
        public string StatusMessages { get; set; } = string.Empty;
    }
}
