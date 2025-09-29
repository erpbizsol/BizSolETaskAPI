using Bizsol_ESMS_API.Model;
using BizsolETask_Api.Models;

namespace Bizsol_ESMS_API.Interface
{
    public interface IHolidayMaster
    {
        public abstract Task<dynamic> SaveHolidayMaster(BizsolETaskConnectionString _BizsolESMSConnectionDetails, TY_HolidayMaster model);
        public abstract Task<IEnumerable<dynamic>> GetHolidayMasterList(BizsolETaskConnectionString _BizsolESMSConnectionDetails);
        public abstract Task<dynamic> GetHolidayMasterByCode(BizsolETaskConnectionString _BizsolESMSConnectionDetails, int code);
        public abstract Task<dynamic> DeleteHolidayMaster(BizsolETaskConnectionString _BizsolESMSConnectionDetails, int code);

    }
}
