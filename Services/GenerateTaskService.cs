using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;
using System.Xml.Linq;

namespace BizsolETask_Api.Services
{
    public class GenerateTaskService:IGenerateTask
    {
        public async Task<IEnumerable<dynamic>> GetTicketType(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_TicketTypeMaster_Details", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetTicketNo(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_GetTicketNo_Details", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetPriorityDetails(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_PriorityMaster_Details", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetClientMasterDetails(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_ClientMaster_Details", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetWorkTypes(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_WorkTypeMaster_Details", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetAssigneds(BizsolETaskConnectionString bizsolESMSConnectionDetails, int code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Code", code);
                var result = await conn.QueryAsync<dynamic>("USP_ClientWiseEmpolyee_Details", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveGenerateTaskTicket(BizsolETaskConnectionString bizsolESMSConnectionDetails, Vw_GenrateTask GenerateTaskMaster)
        {

            var TY_STRUCTUREArry = CommonFunctions.DataTableArrayExecuteSqlQueryWithParameter(bizsolESMSConnectionDetails.ConnectionSql, $"exec [dbo].[USP_InsertProject_Master_New] @Mode='TABLE_STRUCTURE'", null);

            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("Code", GenerateTaskMaster.GenerateTask.FirstOrDefault().Code);
                parameters.Add("UserMaster_Code", GenerateTaskMaster.GenerateTask.FirstOrDefault().UserMaster_Code);
                parameters.Add("GenerateTask", CommonFunctions.MapModelToProcedureTypeDataTable(GenerateTaskMaster.GenerateTask, TY_STRUCTUREArry[0]).AsTableValuedParameter());
                parameters.Add("Attachments", CommonFunctions.MapModelToProcedureTypeDataTable(GenerateTaskMaster.Attachment, TY_STRUCTUREArry[1]).AsTableValuedParameter());

                var result = await conn.QueryAsync<dynamic>("USP_InsertProject_Master_New", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetGenerateTaskTicketDate(BizsolETaskConnectionString bizsolESMSConnectionDetails, string? EmployeeName, string? showBy, string? Status, string ticketNo)
        {
           
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("Mode", "GETDATE");
                if (showBy == "undefined" || showBy == "UsWise")
                {
                    parameters.Add("EmployeeName", EmployeeName);
                    if (Status != "A")
                        parameters.Add("StatusName", Status);
                }
                else
                {
                    if (Status != "A")
                        parameters.Add("StatusName", Status);
                }
                parameters.Add("TicketNo", ticketNo);
                
                var result = await conn.QueryAsync<dynamic>("USP_InsertProject_Master_New", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<dynamic> GetGenerateTaskTicketByCode(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SHOWDATA");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_InsertProject_Master_New", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetAttachment(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "GETA");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_InsertProject_Master_New", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<dynamic> GetTicketsDetails(BizsolETaskConnectionString bizsolESMSConnectionDetails, int TicketNo)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("TicketNo", TicketNo);
                var result = await conn.QueryAsync<dynamic>("USP_CallTicketsDetails_Ticket_New", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<dynamic> GetWorksTimes(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_GetWorksTimes", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<dynamic> DeleteGenerateTask(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "DELETE");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_InsertProject_Master_New", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
