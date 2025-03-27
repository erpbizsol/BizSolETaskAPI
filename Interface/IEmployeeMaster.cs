using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IEmployeeMaster
    {
        public abstract Task<IEnumerable<dynamic>> GetEmployeeMasterList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<dynamic> GetEmployeeMasterByCode(BizsolETaskConnectionString BizsolETaskConnectionString,int Code);
        public abstract Task<dynamic> SaveEmployeeMaster(BizsolETaskConnectionString BizsolETaskConnectionString,TY_EmployeeMaster EmployeeMaster);
        public abstract Task<dynamic> ChangePassword(BizsolETaskConnectionString BizsolETaskConnectionString,TY_EmployeeMaster EmployeeMaster);
    }
}
