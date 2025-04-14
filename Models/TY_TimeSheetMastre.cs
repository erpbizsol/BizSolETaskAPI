namespace BizsolETask_Api.Models
{
    public class TY_TimeSheetMastre
    {
        public int Code { get; set; }
        public int EmployeeName { get; set; }
        public string Date { get; set; }
   
        public string? Remarks { get; set; } = "";
   
        public int UserMaster_Code { get; set; }
        
    }
   



}
