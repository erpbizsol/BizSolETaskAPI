using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class TimeSheetService: ITimeSheet
    {
        public async Task<IEnumerable<dynamic>> GetClientList(BizsolETaskConnectionString bizsolESMSConnectionDetails) 
        { 
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "CLIENTTYPE");
                var result = await conn.QueryAsync<dynamic>("USP_DropDown", parameters, commandType: CommandType.StoredProcedure);

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
    }
}
