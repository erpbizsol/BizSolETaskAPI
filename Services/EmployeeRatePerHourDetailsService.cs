using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace BizsolETask_Api.Services
{
    public class EmployeeRatePerHourDetailsService:IEmployeeRatePerHourDetails
    {
        public async Task<IEnumerable<dynamic>> GetEmployeeRatePerHourDetails(BizsolETaskConnectionString bizsolESMSConnectionDetails, int EmployeeMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "LOCATE");
                parameters.Add("EmployeeMaster_Code", EmployeeMaster_Code);
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeRatePerHourDetails", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> DeleteEmployeeRatePerHourDetails(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "DELETE");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeRatePerHourDetails", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveEmployeeRatePerHourDetails(BizsolETaskConnectionString bizsolESMSConnectionDetails, TY_EmployeeRatePerHourDetails EmployeeRatePerHourDetails)
        {
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Code", EmployeeRatePerHourDetails.Code);
                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("UserMaster_Code", EmployeeRatePerHourDetails.UserMaster_Code);
                parameters.Add("EmployeeMaster_Code", EmployeeRatePerHourDetails.EmployeeMaster_Code);
                parameters.Add("EffectiveDate", EmployeeRatePerHourDetails.EffectiveDate);
                parameters.Add("RatePerHour", EmployeeRatePerHourDetails.RatePerHour);

                var result = await conn.QueryAsync<dynamic>("USP_EmployeeRatePerHourDetails", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

    }
}
