using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IDashboard
    {
        public abstract Task<dynamic> GetEmployeeType(BizsolETaskConnectionString BizsolETaskConnectionString, string Mode, string FromDate, string ToDate,int UserMaster_Code, string? EmployeeMaster_Code);
        public abstract Task<dynamic> GetEmployeePending(BizsolETaskConnectionString BizsolETaskConnectionString ,string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code);
        public abstract Task<dynamic> GetClientPending(BizsolETaskConnectionString BizsolETaskConnectionString, string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code);
    }
}
