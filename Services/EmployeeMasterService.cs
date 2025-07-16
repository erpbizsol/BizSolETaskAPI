using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class EmployeeMasterService:IEmployeeMaster
    {
        public async Task<IEnumerable<dynamic>> GetEmployeeMasterList(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "LOCATE");
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetEmployeeMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, string IsActive, string EmployeeType)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "EMPLOYEETYPE");
                parameters.Add("IsActive", IsActive.Trim());
                parameters.Add("EmployeeType", EmployeeType.Trim());
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetEmployeeMasterByCode(BizsolETaskConnectionString bizsolESMSConnectionDetails,int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SHOWDATA");
                parameters.Add("Code",Code);
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> ChangeEmployeeStatus(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "CHANGESTATUS");
                parameters.Add("Code", Code);
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> GetExcelTemplate(BizsolETaskConnectionString bizsolESMSConnectionDetails,string Mode,string WithData)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode",Mode.Trim());
                parameters.Add("WithData", WithData);
                var result = await conn.QueryAsync<dynamic>("USP_ExcelTemplate", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveEmployeeMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, TY_EmployeeMaster EmployeeMaster)
        {
            var password = CommonFunctions.Encrypt(EmployeeMaster.Password, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Code", EmployeeMaster.Code);
                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("UserMaster_Code", EmployeeMaster.UserMaster_Code);
                parameters.Add("EmployeeName", EmployeeMaster.EmployeeName);
                parameters.Add("EmployeeCard", EmployeeMaster.EmployeeCard);
                parameters.Add("EmployeeType", EmployeeMaster.EmployeeType);
                parameters.Add("Email", EmployeeMaster.Email);
                parameters.Add("MobileNo", EmployeeMaster.MobileNo);
                parameters.Add("Password", password);
                parameters.Add("Numberofdays", EmployeeMaster.Numberofdays);
                parameters.Add("WorkingHours", EmployeeMaster.WorkingHours);
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> ChangePassword(BizsolETaskConnectionString bizsolESMSConnectionDetails, TY_EmployeeMaster EmployeeMaster)
        {
            var password = CommonFunctions.Encrypt(EmployeeMaster.Password, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Code", EmployeeMaster.Code);
                parameters.Add("Mode", "CHANGEPASSWORD");
                parameters.Add("UserMaster_Code", EmployeeMaster.UserMaster_Code);
                parameters.Add("EmployeeName", EmployeeMaster.EmployeeName);
                parameters.Add("EmployeeCard", EmployeeMaster.EmployeeCard);
                parameters.Add("EmployeeType", EmployeeMaster.EmployeeType);
                parameters.Add("Email", EmployeeMaster.Email);
                parameters.Add("MobileNo", EmployeeMaster.MobileNo);
                parameters.Add("Password", password);
                var result = await conn.QueryAsync<dynamic>("USP_EmployeeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> ImportEmployeeMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, IEnumerable<TY_EmployeeMaster> EmployeeMaster,int UserMaster_Code)
        {

            var TY_STRUCTUREArry = CommonFunctions.DataTableArrayExecuteSqlQueryWithParameter(bizsolESMSConnectionDetails.ConnectionSql, $"exec [dbo].[USP_EmployeeMaster] @Mode='TABLE_STRUCTURE'", null);
            var employeeList = EmployeeMaster.ToList();

            foreach (var employee in employeeList)
            {
                employee.Password = CommonFunctions.Encrypt(employee.Password, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
            }
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Mode", "IMPORT");
                parameters.Add("UserMaster_Code",UserMaster_Code);
                parameters.Add("EmployeeMaster", CommonFunctions.MapModelToProcedureTypeDataTable(EmployeeMaster, TY_STRUCTUREArry[0]).AsTableValuedParameter());

                var result = await conn.QueryAsync<dynamic>("USP_EmployeeMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

    }
}
