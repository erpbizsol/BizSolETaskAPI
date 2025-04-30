using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace BizsolETask_Api.Services
{
    public class ReportServices:IReport
    {
        public async Task<dynamic> GetTimeSheetReport(BizsolETaskConnectionString bizsolESMSConnectionDetails, string FromDate, string ToDate,
        string ClientMaster_Code, string WorkTypeMaster_Code, string EmployeeMaster_Code,string ReportType)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
           
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                parameters.Add("ClientMaster_Code", ClientMaster_Code);
                parameters.Add("WorkTypeMaster_Code", WorkTypeMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code);
                parameters.Add("ReportType", ReportType);
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetClientType(BizsolETaskConnectionString bizsolESMSConnectionDetails, string FromDate, string ToDate)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", "ClientType");
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
         
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew", parameters, commandType: CommandType.StoredProcedure);

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

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew", parameters, commandType: CommandType.StoredProcedure);

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

                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetReportNew", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }

}
