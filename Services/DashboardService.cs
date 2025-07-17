using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class DashboardService: IDashboard
    {
        public async Task<dynamic> GetClientType(BizsolETaskConnectionString bizsolESMSConnectionDetails, string FromDate, string ToDate)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "ClientType");
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetWorkType(BizsolETaskConnectionString bizsolESMSConnectionDetails, string FromDate, string ToDate)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "WorkType");
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetEmployeeType(BizsolETaskConnectionString bizsolESMSConnectionDetails, string FromDate, string ToDate)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "EmployeeType");
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetEmployeeHours(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "GETHOUR");
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<dynamic> GetEmployeeWiseStatus(BizsolETaskConnectionString bizsolESMSConnectionDetails, string FromDate, string ToDate, int UserMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                var result = await conn.QueryAsync<dynamic>("USP_GetEmployeeWiseStatus", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

    }
}
