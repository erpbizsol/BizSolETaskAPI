﻿using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

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
        public async Task<IEnumerable<dynamic>> GetAssigneds(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeMasterMaster_Details", parameters, commandType: CommandType.StoredProcedure);

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
                parameters.Add("GenerateTask", CommonFunctions.MapModelToProcedureTypeDataTable(GenerateTaskMaster.GenerateTask, TY_STRUCTUREArry[0]).AsTableValuedParameter());
                parameters.Add("Attachment", CommonFunctions.MapModelToProcedureTypeDataTable(GenerateTaskMaster.Attachment, TY_STRUCTUREArry[1]).AsTableValuedParameter());

                var result = await conn.QueryAsync<dynamic>("USP_InsertProject_Master_New", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
