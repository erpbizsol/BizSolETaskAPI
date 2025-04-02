using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class WorkTypeMasterService: IWorkTypeMaster
    {
        public async Task<IEnumerable<dynamic>> GetWorkTypeMasterList(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "LOCATE");
                var result = await conn.QueryAsync<dynamic>("USP_WorkTypeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetWorkTypeMasterByCode(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SHOWDATA");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_WorkTypeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> DeleteWorkTypeMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "DELETE");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_WorkTypeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveWorkTypeMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, TY_WorkTypeMaster WorkTypeMaster)
        {
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Code", WorkTypeMaster.Code);
                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("UserMaster_Code", WorkTypeMaster.UserMaster_Code);
                parameters.Add("WorkTypeName", WorkTypeMaster.WorkType);

                var result = await conn.QueryAsync<dynamic>("USP_WorkTypeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

    }
}
