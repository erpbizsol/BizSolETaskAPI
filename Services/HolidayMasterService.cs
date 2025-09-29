using Bizsol_ESMS_API.Interface;
using Bizsol_ESMS_API.Model;
using BizsolETask_Api.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Bizsol_ESMS_API.Service
{
    public class HolidayMasterService:IHolidayMaster
    {
        public async Task<dynamic> SaveHolidayMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, TY_HolidayMaster HolidayMaster)
        {
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Code", HolidayMaster.Code);
                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("UserMaster_Code", HolidayMaster.UserMaster_Code);
                parameters.Add("Vacation", HolidayMaster.Vacation);
                parameters.Add("Date", HolidayMaster.Date);
                var result = await conn.QueryAsync<dynamic>("USP_HolidayMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetHolidayMasterList(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "LOCATE");
                var result = await conn.QueryAsync<dynamic>("USP_HolidayMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetHolidayMasterByCode(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SHOWDATA");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_HolidayMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> DeleteHolidayMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "DELETE");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_HolidayMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
