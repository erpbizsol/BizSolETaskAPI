using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IGenerateTask
    {
        public abstract Task<IEnumerable<dynamic>> GetTicketType(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetTicketNo(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetPriorityDetails(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetClientMasterDetails(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetWorkTypes(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetAssigneds(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<dynamic> SaveGenerateTaskTicket(BizsolETaskConnectionString BizsolETaskConnectionString, Vw_GenrateTask GenerateTask);
    }
}
