using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BizsolETask_Api.Services
{
    public class TaskNatureMasterService : ITaskNatureMaster
    {

        public async Task<IEnumerable<dynamic>> GetTaskNatureMasterList(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "LOCATE");
                var result = await conn.QueryAsync<dynamic>("USP_SaveTaskNatureMaster", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<dynamic> GetTaskNatureMasterByCode(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SHOWDATA");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_SaveTaskNatureMaster", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<dynamic> DeleteTaskNatureMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "DELETE");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_SaveTaskNatureMaster", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<dynamic> SaveTaskNatureMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, TY_TaskNatureMaster TaskNatureMaster)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Code", TaskNatureMaster.Code);
                parameters.Add("Mode", "SAVE");
                parameters.Add("UserMaster_Code", TaskNatureMaster.UserMaster_Code);
                parameters.Add("Nature", TaskNatureMaster.Nature.Trim());

                var result = await conn.QueryAsync<dynamic>("USP_SaveTaskNatureMaster", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
