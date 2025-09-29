using BizsolETask_Api.Models;
using static BizsolETask_Api.Services.EmployeeMasterService;

namespace BizsolETask_Api.Interface
{
    public interface IEmployeeMaster
    {
        public abstract Task<IEnumerable<dynamic>> GetEmployeeMasterList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetEmployeeMaster(BizsolETaskConnectionString BizsolETaskConnectionString,string IsActive,string EmployeeType);
        public abstract Task<dynamic> GetEmployeeMasterByCode(BizsolETaskConnectionString BizsolETaskConnectionString,int Code);
        public abstract Task<dynamic> ChangeEmployeeStatus(BizsolETaskConnectionString BizsolETaskConnectionString,int Code);
        public abstract Task<dynamic> GetExcelTemplate(BizsolETaskConnectionString BizsolETaskConnectionString,string Mode,string WithData);
        public abstract Task<dynamic> SaveEmployeeMaster(BizsolETaskConnectionString BizsolETaskConnectionString,TY_EmployeeMaster EmployeeMaster);
        public abstract Task<dynamic> ChangePassword(BizsolETaskConnectionString BizsolETaskConnectionString,TY_EmployeeMaster EmployeeMaster);
        public abstract Task<dynamic> ImportEmployeeMaster(BizsolETaskConnectionString BizsolETaskConnectionString, IEnumerable<TY_EmployeeMaster> EmployeeMaster, int UserMaster_Code);
        public abstract Task<dynamic> SaveConfigMaster(BizsolETaskConnectionString BizsolETaskConnectionString, ConfigMasterRequest Configrequest);
        public abstract Task<IEnumerable<dynamic>> ShowConfig(BizsolETaskConnectionString BizsolETaskConnectionString);
    }
}
