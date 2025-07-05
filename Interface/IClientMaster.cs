using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IClientMaster
    {
        public abstract Task<IEnumerable<dynamic>> GetClientMasterList(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<dynamic> GetClientMasterByCode(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> DeleteClientMaster(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> SaveClientMaster(BizsolETaskConnectionString BizsolETaskConnectionString, TY_ClientMaster ClientMaster);
        public abstract Task<dynamic> ImportClientMaster(BizsolETaskConnectionString BizsolETaskConnectionString, IEnumerable<TY_ClientMaster> ClientMaster, int UserMaster_Code);
        public abstract Task<dynamic> AssignClientsToEmployee(BizsolETaskConnectionString BizsolETaskConnectionString, IEnumerable<TY_AssignClient>  AssignClient);
    }
}
