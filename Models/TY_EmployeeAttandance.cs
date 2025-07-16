namespace BizsolETask_Api.Models
{
    public class TY_EmployeeAttandance
    {
        public int EmployeeMaster_Code { get; set; }
        public string? Date { get; set; }
        public string? Status { get; set; } = "";
        public int WorkingHours { get; set; } 
        public int UserMaster_Code { get; set; } 
    }
}
