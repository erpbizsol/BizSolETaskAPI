using BizsolETask_Api.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BizsolETask_Api.Interface
{
    public interface IGenerateTask
    {
        public abstract Task<IEnumerable<dynamic>> GetTicketType(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetTicketNo(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetPriorityDetails(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetClientMasterDetails(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetWorkTypes(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetAssigneds(BizsolETaskConnectionString BizsolETaskConnectionString,int code);
        public abstract Task<dynamic> SaveGenerateTaskTicket(BizsolETaskConnectionString BizsolETaskConnectionString, Vw_GenrateTask GenerateTask);
        public abstract Task<IEnumerable<dynamic>> GetGenerateTaskTicketDate(BizsolETaskConnectionString bizsolESMSConnectionDetails, string EmployeeName, string showBy, string Status, string ticketNo);
        public abstract Task<dynamic> GetGenerateTaskTicketByCode(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> GetAttachment(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> GetTicketsDetails(BizsolETaskConnectionString BizsolETaskConnectionString, int TicketNo);
        public abstract Task<dynamic> GetWorksTimes(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> DeleteGenerateTask(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<IEnumerable<dynamic>> GetEmployeeWiseClient(BizsolETaskConnectionString BizsolETaskConnectionString, string Code);
        public abstract Task<IEnumerable<dynamic>> DateWiseUserWiseTime(BizsolETaskConnectionString BizsolETaskConnectionString, string TickatNo);
        public abstract Task<IEnumerable<dynamic>> GetGenerateTaskTicketDatePending(BizsolETaskConnectionString bizsolESMSConnectionDetails, string EmployeeName, string Status, string ticketNo, string ReportType, string? FromDate, string? ToDate);
        public abstract Task<IEnumerable<dynamic>> GetAssignedss(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetTaskNatureMaster(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<dynamic> GetTicketNolist(BizsolETaskConnectionString BizsolETaskConnectionString, int TickatN);
        public abstract Task<IEnumerable<dynamic>> GetMenuName(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetEmployeeWiseUserName(BizsolETaskConnectionString BizsolETaskConnectionString, string Code);
        public abstract Task<IEnumerable<dynamic>> GetUserName(BizsolETaskConnectionString BizsolETaskConnectionString, string Code);

      
    }
}
