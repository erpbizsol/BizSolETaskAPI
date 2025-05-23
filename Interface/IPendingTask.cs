using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IPendingTask
    {
        public abstract Task<IEnumerable<dynamic>> GetStatuss(BizsolETaskConnectionString BizsolETaskConnectionString);
        public abstract Task<IEnumerable<dynamic>> GetStatusType(BizsolETaskConnectionString BizsolETaskConnectionString,int Code);
    }
}
