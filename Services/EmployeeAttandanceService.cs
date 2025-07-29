using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class EmployeeAttandanceService:IEmployeeAttandance
    {
        public async Task<IEnumerable<dynamic>> GetEmployeeIdCard(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_GetEmployeeCard", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetCardwiseEmployeeName(BizsolETaskConnectionString bizsolESMSConnectionDetails,string CardCode)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("CardCode", CardCode);
                var result = await conn.QueryAsync<dynamic>("USP_GetCardwiseEmployeeName", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetEmployeeAttandance(BizsolETaskConnectionString bizsolESMSConnectionDetails, string EmployeeCode, string Date)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "GETDATA");
                parameters.Add("EmployeeCode", EmployeeCode);
                parameters.Add("Date", Date);
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeAttandance", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveEmployeeAttandance(BizsolETaskConnectionString bizsolESMSConnectionDetails, TY_EmployeeAttandance EmployeeAttandance)
        {
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("EmployeeMaster_Code", EmployeeAttandance.EmployeeMaster_Code);
                parameters.Add("WorkingHours", EmployeeAttandance.WorkingHours);
                parameters.Add("RemainingHours", EmployeeAttandance.RemainingHours);
                parameters.Add("Statuss", EmployeeAttandance.Status);
                parameters.Add("Date", EmployeeAttandance.Date);
                parameters.Add("UserMaster_Code", EmployeeAttandance.UserMaster_Code);
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeAttandance", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveEmployeeStatus(BizsolETaskConnectionString bizsolESMSConnectionDetails, string? EmployeeCode, string? Date, string? Status,int UserMaster_Code)
        {
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "UPDATESTATUS");
                parameters.Add("EmployeeCode", EmployeeCode);
                parameters.Add("Statuss", Status);
                parameters.Add("Date", Date);
                parameters.Add("UserMaster_Code",UserMaster_Code);
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeAttandance", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }

}
