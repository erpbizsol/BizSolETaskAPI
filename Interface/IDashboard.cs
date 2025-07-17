using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IDashboard
    {
        public abstract Task<dynamic> GetClientType(BizsolETaskConnectionString BizsolETaskConnectionString, string FromDate, string ToDate);
        public abstract Task<dynamic> GetWorkType(BizsolETaskConnectionString BizsolETaskConnectionString, string FromDate, string ToDate);
        public abstract Task<dynamic> GetEmployeeType(BizsolETaskConnectionString BizsolETaskConnectionString, string FromDate, string ToDate);
        public abstract Task<dynamic> GetEmployeeHours(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<dynamic> GetEmployeeWiseStatus(BizsolETaskConnectionString BizsolETaskConnectionString, string FromDate, string ToDate,int UserMaster_Code);

    }
}
