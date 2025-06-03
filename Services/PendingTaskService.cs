using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class PendingTaskService:IPendingTask
    {
        public async Task<IEnumerable<dynamic>> GetStatuss(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_StatusMaster_Details_New", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetStatusType(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_CallTicketDeveloperData_New", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SavePendingTask(BizsolETaskConnectionString bizsolESMSConnectionDetails, Vw_PendingTask PendingTaskMaster)
        {

            var TY_STRUCTUREArry = CommonFunctions.DataTableArrayExecuteSqlQueryWithParameter(bizsolESMSConnectionDetails.ConnectionSql, $"exec [dbo].[USP_CallTicketUpdate_Developer_New] @Mode='TABLE_STRUCTURE'", null);

            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("Code", PendingTaskMaster.PendingTask.FirstOrDefault().Code);
                parameters.Add("PendingTask", CommonFunctions.MapModelToProcedureTypeDataTable(PendingTaskMaster.PendingTask, TY_STRUCTUREArry[0]).AsTableValuedParameter());
                parameters.Add("Attachments", CommonFunctions.MapModelToProcedureTypeDataTable(PendingTaskMaster.Attachment, TY_STRUCTUREArry[1]).AsTableValuedParameter());

                var result = await conn.QueryAsync<dynamic>("USP_CallTicketUpdate_Developer_New", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetPendingTaskReport(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code,string Status)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("EmployeeCode", Code);
                parameters.Add("StatusTask", Status);
                var result = await conn.QueryAsync<dynamic>("USP_PendingTaskUserWise_new", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
