namespace BizsolETask_Api.Models
{
    public class TY_EmployeeMaster
    {
        public int Code { get; set; }
        public int EmployeeCard { get; set; }
        public string? EmployeeName { get; set; } = "";
        public string? Password { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? MobileNo { get; set; } = "";
        public string? EmployeeType { get; set; } = "";
        public string? Status { get; set; } = "";
        public int UserMaster_Code { get; set; } 
    }
}
