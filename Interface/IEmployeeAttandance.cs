using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IEmployeeAttandance
    {
        public abstract Task<IEnumerable<dynamic>> GetEmployeeIdCard(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetCardwiseEmployeeName(BizsolETaskConnectionString BizsolETaskConnectionString, string CardCode);
        public abstract Task<IEnumerable<dynamic>> GetEmployeeAttandance(BizsolETaskConnectionString BizsolETaskConnectionString, string EmployeeCode, string Date);
        public abstract Task<dynamic> SaveEmployeeAttandance(BizsolETaskConnectionString BizsolETaskConnectionString, TY_EmployeeAttandance EmployeeAttandance);
        public abstract Task<dynamic> SaveEmployeeStatus(BizsolETaskConnectionString BizsolETaskConnectionString, string? EmployeeCode, string? Date, string? Status, int UserMaster_Code);
    }
}
