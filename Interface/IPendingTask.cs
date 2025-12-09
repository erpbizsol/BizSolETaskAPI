using BizsolETask_Api.Models;
using static BizsolETask_Api.Services.PendingTaskService;

namespace BizsolETask_Api.Interface
{
    public interface IPendingTask
    {
        public abstract Task<IEnumerable<dynamic>> GetStatuss(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetReason(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetStatusType(BizsolETaskConnectionString BizsolETaskConnectionString,int Code);
        public abstract Task<dynamic> SavePendingTask(BizsolETaskConnectionString BizsolETaskConnectionString, Vw_PendingTask PendingTask);
        public abstract Task<IEnumerable<dynamic>> GetPendingTaskReport(BizsolETaskConnectionString BizsolETaskConnectionString, int Code,string Status);
        public abstract Task<IEnumerable<dynamic>> GetCallTicketMasterPlanningDetails(BizsolETaskConnectionString BizsolETaskConnectionString, int EmployeeCode, string Year, int WeekNo);
        public abstract Task<dynamic> UpdateCallTicketMasterPlanning(BizsolETaskConnectionString BizsolETaskConnectionString,UpdateCallTicketPlanningRequest req);
    }
}
