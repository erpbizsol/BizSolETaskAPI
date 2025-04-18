using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface ITimeSheet
    {
        public abstract Task<IEnumerable<dynamic>> GetClientList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetWorkTypeList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetEmpDateList(BizsolETaskConnectionString BizsolETaskConnectionString, int EmployeeName,string WorkDate);
        public abstract Task<List<dynamic>> SaveTimeSheetMaster(BizsolETaskConnectionString BizsolETaskConnectionString, Vw_TimeSheet viewModel);
        public abstract Task<dynamic> Delete(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
    }
}
