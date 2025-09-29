using Bizsol_ESMS_API.Interface;
using Bizsol_ESMS_API.Model;
using BizsolETask_Api.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Bizsol_ESMS_API.Service
{
    public class CurrentDateService: ICurrentDate
    {
  
        public async Task<IEnumerable<dynamic>> GetCurrentDate(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_GetCurrentDate", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
