using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class DashboardService: IDashboard
    {
        public async Task<dynamic> GetEmployeeType(BizsolETaskConnectionString bizsolESMSConnectionDetails, string Mode, string FromDate, string ToDate,int UserMaster_Code, string? EmployeeMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", Mode.Trim());
                parameters.Add("ReportType", "EMPLOYEETYPE");
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code=="null"?null: EmployeeMaster_Code);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord_test", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetEmployeePending(BizsolETaskConnectionString bizsolESMSConnectionDetails, string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "STATUSP");
                parameters.Add("Mode", Mode.Trim());
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code == "null" ? null : EmployeeMaster_Code);
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord_test", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetClientPending(BizsolETaskConnectionString bizsolESMSConnectionDetails, string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "CLIENTSTATUS");
                parameters.Add("Mode", Mode.Trim());
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code == "null" ? null : EmployeeMaster_Code);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord_test", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetNormalPriority(BizsolETaskConnectionString bizsolESMSConnectionDetails, string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "TICKETPRIORITY");
                parameters.Add("Mode", Mode.Trim());
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code == "null" ? null : EmployeeMaster_Code);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord_test", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetHighPriority(BizsolETaskConnectionString bizsolESMSConnectionDetails, string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "TICKETPRIORITYH");
                parameters.Add("Mode", Mode.Trim());
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code == "null" ? null : EmployeeMaster_Code);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord_test", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<dynamic> GetEmployeeEfficiency(BizsolETaskConnectionString bizsolESMSConnectionDetails, string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "TICKETR");
                parameters.Add("Mode", Mode.Trim());
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code == "null" ? null : EmployeeMaster_Code);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord_test", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<dynamic> GetEMPLOYEEWORKEDHOURS(BizsolETaskConnectionString bizsolESMSConnectionDetails, string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "EMPLOYEEWORKEDHOURS");
                parameters.Add("Mode", Mode.Trim());
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code == "null" ? null : EmployeeMaster_Code);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord_test", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetCLIENTWORKEDHOURS(BizsolETaskConnectionString bizsolESMSConnectionDetails, string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "CLIENTWORKEDHOURS");
                parameters.Add("Mode", Mode.Trim());
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code == "null" ? null : EmployeeMaster_Code);

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew_Dashbord_test", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        
    }
}
