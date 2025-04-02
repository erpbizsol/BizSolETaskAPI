using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IStatusMaster
    {
        public abstract Task<IEnumerable<dynamic>> GetStatusMasterList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<dynamic> GetStatusMasterByCode(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> DeleteStatusMaster(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> SaveStatusMaster(BizsolETaskConnectionString BizsolETaskConnectionString, TY_StatusMaster StatusMaster);
    }
}
