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
        public abstract Task<IEnumerable<dynamic>> GetGenerateTaskTicketDate(BizsolETaskConnectionString bizsolESMSConnectionDetails, string EmployeeName, string showBy, string Status, string ticketNo);
        public abstract Task<dynamic> GetGenerateTaskTicketByCode(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> GetAttachment(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> GetTicketsDetails(BizsolETaskConnectionString BizsolETaskConnectionString, int TicketNo);
    }
}
