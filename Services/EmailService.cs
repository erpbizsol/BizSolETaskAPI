using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class EmailService:IEmail
    {
        public async Task<IEnumerable<dynamic>> SenEmailMassage(BizsolETaskConnectionString bizsolESMSConnectionDetails,int Code)
        {

            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Code", Code);
                parameters.Add("Mode", "NEW");
                var result = await conn.QueryAsync<dynamic>("USP_SendEmail", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
