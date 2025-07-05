using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BizsolETask_Api.Services
{
    public class ClientMasterService:IClientMaster
    {
        public async Task<IEnumerable<dynamic>> GetClientMasterList(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "LOCATE");
                var result = await conn.QueryAsync<dynamic>("USP_ClientMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetClientMasterByCode(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SHOWDATA");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_ClientMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> DeleteClientMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "DELETE");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_ClientMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveClientMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, TY_ClientMaster ClientMaster)
        {
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Code", ClientMaster.Code);
                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("UserMaster_Code", ClientMaster.UserMaster_Code);
                parameters.Add("ClientName", ClientMaster.ClientName.Trim());
                parameters.Add("DefaultEmails", ClientMaster.DefaultEmails.Trim());
                parameters.Add("Employee_Codes", ClientMaster.Employee_Codes.Trim());

                var result = await conn.QueryAsync<dynamic>("USP_ClientMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> ImportClientMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, IEnumerable<TY_ClientMaster> ClientMaster, int UserMaster_Code)
        {
            var TY_STRUCTUREArry = CommonFunctions.DataTableArrayExecuteSqlQueryWithParameter(bizsolESMSConnectionDetails.ConnectionSql, $"exec [dbo].[USP_ClientMaster] @Mode='TABLE_STRUCTURE'", null);

            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Mode", "IMPORT");
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("ClientMaster", CommonFunctions.MapModelToProcedureTypeDataTable(ClientMaster, TY_STRUCTUREArry[0]).AsTableValuedParameter());

                var result = await conn.QueryAsync<dynamic>("USP_ClientMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> AssignClientsToEmployee(BizsolETaskConnectionString bizsolESMSConnectionDetails, IEnumerable<TY_AssignClient>  AssignClient)
        {
            var TY_STRUCTUREArry = CommonFunctions.DataTableArrayExecuteSqlQueryWithParameter(bizsolESMSConnectionDetails.ConnectionSql, $"exec [dbo].[USP_AssignClientsToEmployee] @Mode='TABLE_STRUCTURE'", null);
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SAVE");
                parameters.Add("AssignClients", CommonFunctions.MapModelToProcedureTypeDataTable(AssignClient, TY_STRUCTUREArry[0]).AsTableValuedParameter());
                var result = await conn.QueryAsync<dynamic>("USP_AssignClientsToEmployee", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
