using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IEmail
    {
        public abstract Task<IEnumerable<dynamic>> SenEmailMassage(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code);

    }
}
