namespace BizsolETask_Api.Models
{
    public class TY_StatusMaster
    {
        public int Code { get; set; }
        public string? StatusName { get; set; } = "";
        public string? StatusDescription { get; set; } = "";
        public int UserMaster_Code { get; set; }

    }
}
