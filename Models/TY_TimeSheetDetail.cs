namespace BizsolETask_Api.Models
{
    public class TY_TimeSheetDetail
    {
        public int Code { get; set; }
        public int ClientMaster_Code { get; set; }
        public string? FromHr { get; set; } = "";
        public string? ToHr { get; set; } = "";
        public int TimeinMinutes { get; set; }
        public int WorkTypeMaster_Code { get; set; }
        public string? Remarks { get; set; } = "";
    }
}
