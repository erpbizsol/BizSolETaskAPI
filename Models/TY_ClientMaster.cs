using Microsoft.AspNetCore.Http.HttpResults;

namespace BizsolETask_Api.Models
{
    public class TY_ClientMaster
    {
        public int Code { get; set; }
        public string? ClientName { get; set; } = "";
        public string? DefaultEmails { get; set; } = "";
        public string? Employee_Codes { get; set; } = "";
        public int UserMaster_Code { get; set; }
    }
}
