using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IWorkTypeMaster
    {
        public abstract Task<IEnumerable<dynamic>> GetWorkTypeMasterList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<dynamic> GetWorkTypeMasterByCode(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> DeleteWorkTypeMaster(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> SaveWorkTypeMaster(BizsolETaskConnectionString BizsolETaskConnectionString, TY_WorkTypeMaster WorkTypeMaster);
    }
}
