using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IUserModuleMaster
    {
        public abstract Task<IEnumerable<dynamic>> GetUserModuleMasterList(BizsolETaskConnectionString BizsolETaskConnectionString,string UserType);
    }
}
