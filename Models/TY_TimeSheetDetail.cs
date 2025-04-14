namespace BizsolETask_Api.Models
{
    public class TY_TimeSheetDetail
    {
        public int ClientName { get; set; }
        public string? FromHr { get; set; } = "";
        public string? ToHr { get; set; } = "";
        public int TimeinMinutes { get; set; }
        public int WorkType { get; set; }
        public string? Remarks1 { get; set; } = "";
    }
}
