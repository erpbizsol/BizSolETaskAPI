using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace BizsolETask_Api.Services
{
    public class PendingTaskService : IPendingTask
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
        public async Task<IEnumerable<dynamic>> GetPendingTaskReport(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code, string Status)
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
        public async Task<IEnumerable<dynamic>> GetCallTicketMasterPlanningDetails(BizsolETaskConnectionString bizsolESMSConnectionDetails, int EmployeeCode, string Year, int WeekNo)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("EmployeeCode", EmployeeCode);
                parameters.Add("Year", Year);
                parameters.Add("WeekNo", WeekNo);
                var result = await conn.QueryAsync<dynamic>("USP_GetCallTicketMaster_PlanningDetails", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public class UpdateCallTicketPlanningRequest
        {
            public int Code { get; set; }
            public int? AssignedEmployeeCode { get; set; }
            public int? PlanPriority { get; set; }
            public string? PlanDate { get; set; }
            public int? Year { get; set; }
            public int? WeekNo { get; set; }
            public int? StatusName { get; set; }
            public string? RequiredPlanDiscuss { get; set; }
        }
        public async Task<dynamic> UpdateCallTicketMasterPlanning(BizsolETaskConnectionString bizsolESMSConnectionDetails, UpdateCallTicketPlanningRequest req)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {

                var parameters = new DynamicParameters();
                parameters.Add("Code", req.Code);

                if (req.AssignedEmployeeCode.HasValue)
                {
                    parameters.Add("AssignedEmployeeCode", req.AssignedEmployeeCode.Value);
                }
                else
                {
                    parameters.Add("AssignedEmployeeCode", null);
                }

                if (req.PlanPriority.HasValue)
                {
                    parameters.Add("PlanPriority", req.PlanPriority.Value);
                }
                else
                {
                    parameters.Add("PlanPriority", null);
                }
                if (!string.IsNullOrWhiteSpace(req.PlanDate))
                {
                    DateTime parsed;
                    bool ok = DateTime.TryParseExact(req.PlanDate.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed);
                    if (ok)
                    {
                        parameters.Add("PlanDate", parsed.Date, DbType.Date);
                    }
                    else
                    {
                        parameters.Add("PlanDate", null, DbType.Date);
                    }
                }
                else
                {
                    parameters.Add("PlanDate", null, DbType.Date);
                }
                if (req.StatusName.HasValue)
                {
                    parameters.Add("StatusName", req.StatusName.Value);
                }
                else
                {
                    parameters.Add("StatusName", null);
                }
                if (!string.IsNullOrWhiteSpace(req.RequiredPlanDiscuss))
                {
                    parameters.Add("RequiredPlanDiscuss", req.RequiredPlanDiscuss.Trim());
                }
                else
                {
                    parameters.Add("RequiredPlanDiscuss", null);
                }
                if (req.Year.HasValue)
                {
                    parameters.Add("Year", req.Year);
                }
                else
                {
                    parameters.Add("Year", null);
                }
                if (req.WeekNo.HasValue)
                {
                    parameters.Add("WeekNo", req.WeekNo.Value);
                }
                else
                {
                    parameters.Add("WeekNo", null); 
                }
                var result = await conn.QueryAsync<dynamic>("USP_UpdateCallTicketMaster_Planning", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
               
            }
        }
        public async Task<IEnumerable<dynamic>> GetReason(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_GetReason", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
