namespace BizsolETask_Api.Models
{
    public class UpdateEmailRequest
    {
        public int Code { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
