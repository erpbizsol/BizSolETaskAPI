using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface ITaskNatureMaster
    {
        public abstract Task<IEnumerable<dynamic>> GetTaskNatureMasterList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<dynamic> GetTaskNatureMasterByCode(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> DeleteTaskNatureMaster(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> SaveTaskNatureMaster(BizsolETaskConnectionString BizsolETaskConnectionString, TY_TaskNatureMaster TaskNatureMaster);
    }
}
