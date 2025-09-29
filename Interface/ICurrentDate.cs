using Bizsol_ESMS_API.Model;
using BizsolETask_Api.Models;

namespace Bizsol_ESMS_API.Interface
{
    public interface ICurrentDate
    {
        public abstract Task<IEnumerable<dynamic>> GetCurrentDate(BizsolETaskConnectionString _BizsolESMSConnectionDetails);
    }
}
