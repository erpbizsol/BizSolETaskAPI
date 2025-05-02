using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class TimeSheetService : ITimeSheet
    {
        public async Task<IEnumerable<dynamic>> GetClientList(BizsolETaskConnectionString bizsolESMSConnectionDetails ,int EmployeeName)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "GETDEP");
                parameters.Add("EmployeeName", EmployeeName);
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetMasterNew", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetWorkTypeList(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "WORKTYPE");
                var result = await conn.QueryAsync<dynamic>("USP_DropDown", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<IEnumerable<dynamic>> GetEmpDateList(BizsolETaskConnectionString bizsolESMSConnectionDetails, int EmployeeName, string WorkDate)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "GetData");
                parameters.Add("EmployeeName", EmployeeName);
                parameters.Add("Date", WorkDate);
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetMasterNew", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveTimeSheetMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, Vw_TimeSheet TimeSheetMaster)
        {
            var TY_STRUCTUREArry = CommonFunctions.DataTableArrayExecuteSqlQueryWithParameter(bizsolESMSConnectionDetails.ConnectionSql, $"exec [dbo].[USP_TimeSheetMasterNew] @Mode='TABLE_STRUCTURE'", null);

            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("Code", TimeSheetMaster.TimeSheetMaster.FirstOrDefault().Code);
                parameters.Add("TimeSheetDetail_Code", TimeSheetMaster.TimeSheetDetail.FirstOrDefault().Code);
                parameters.Add("TimeSheetMaster", CommonFunctions.MapModelToProcedureTypeDataTable(TimeSheetMaster.TimeSheetMaster, TY_STRUCTUREArry[0]).AsTableValuedParameter());
                parameters.Add("TimeSheetDetail", CommonFunctions.MapModelToProcedureTypeDataTable(TimeSheetMaster.TimeSheetDetail, TY_STRUCTUREArry[1]).AsTableValuedParameter());

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetMasterNew", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<dynamic> Delete(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code,int TimeSheetDetail_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "DELETE");
                parameters.Add("Code", Code);
                parameters.Add("TimeSheetDetail_Code", TimeSheetDetail_Code);
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetMasterNew", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<dynamic> TimeSheetRemark(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code, string Remark)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "R_Update");
                parameters.Add("Code", Code);
                parameters.Add("Remarks", Remark);
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetMasterNew", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetClientNameList(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "CLIENTTYPE");
                var result = await conn.QueryAsync<dynamic>("USP_DropDown", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetDate(BizsolETaskConnectionString bizsolESMSConnectionDetails,int EmployeeName)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "GETDATE");
                parameters.Add("EmployeeName", EmployeeName);
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetMasterNew", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}

