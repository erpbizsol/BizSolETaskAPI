using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IReport
    {
        public abstract Task<dynamic> GetTimeSheetReport(BizsolETaskConnectionString BizsolETaskConnectionString,string FromDate,string ToDate,
        string ClientMaster_Code, string WorkTypeMaster_Code, string EmployeeMaster_Code, string ReportType);

        public abstract Task<dynamic> GetClientType(BizsolETaskConnectionString BizsolETaskConnectionString, string FromDate, string ToDate);
        public abstract Task<dynamic> GetWorkType(BizsolETaskConnectionString BizsolETaskConnectionString, string FromDate, string ToDate);
        public abstract Task<dynamic> GetEmployeeType(BizsolETaskConnectionString BizsolETaskConnectionString, string FromDate, string ToDate);
    }
}
