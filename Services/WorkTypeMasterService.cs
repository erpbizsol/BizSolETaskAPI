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
                parameters.Add("WorkType", WorkTypeMaster.WorkType.Trim());

                var result = await conn.QueryAsync<dynamic>("USP_WorkTypeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> ImportWorkTypeMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, IEnumerable<TY_WorkTypeMaster> WorkTypeMaster, int UserMaster_Code)
        {
            var TY_STRUCTUREArry = CommonFunctions.DataTableArrayExecuteSqlQueryWithParameter(bizsolESMSConnectionDetails.ConnectionSql, $"exec [dbo].[USP_WorkTypeMaster] @Mode='TABLE_STRUCTURE'", null);
           
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Mode", "IMPORT");
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("WorkTypeMaster", CommonFunctions.MapModelToProcedureTypeDataTable(WorkTypeMaster, TY_STRUCTUREArry[0]).AsTableValuedParameter());

                var result = await conn.QueryAsync<dynamic>("USP_WorkTypeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
