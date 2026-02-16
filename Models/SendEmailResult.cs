namespace BizsolETask_Api.Models
{
    public class SendEmailResult
    {
        public int SentCount { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
