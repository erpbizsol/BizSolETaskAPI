using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface ITimeSheet
    {
        public abstract Task<IEnumerable<dynamic>> GetClientList(BizsolETaskConnectionString BizsolETaskConnectionString,int EmployeeName);
        public abstract Task<IEnumerable<dynamic>> GetWorkTypeList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetEmpDateList(BizsolETaskConnectionString BizsolETaskConnectionString, int EmployeeName,string WorkDate);
        public abstract Task<dynamic> SaveTimeSheetMaster(BizsolETaskConnectionString BizsolETaskConnectionString, Vw_TimeSheet viewModel);
        public abstract Task<dynamic> Delete(BizsolETaskConnectionString BizsolETaskConnectionString, int Code,int TimeSheetDetail_Code);
        public abstract Task<dynamic> TimeSheetRemark(BizsolETaskConnectionString BizsolETaskConnectionString, int Code, string Remark);
        public abstract Task<IEnumerable<dynamic>> GetClientNameList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetDate(BizsolETaskConnectionString BizsolETaskConnectionString, int EmployeeName);
    }
}
