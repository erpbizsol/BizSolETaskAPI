namespace BizsolETask_Api.Models
{
    public class SendEmailRequest
    {
        public List<int> Codes { get; set; } = new List<int>();
        /// <summary>Optional. Default is "Rating".</summary>
        public string? Mode { get; set; }
    }
}
