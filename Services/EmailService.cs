using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebPush;

namespace BizsolETask_Api.Services
{
    public class EmailService : IEmail
    {
        public async Task<IEnumerable<dynamic>> SenEmailMassage(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code, string Mode)
        {

            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Code", Code);
                parameters.Add("Mode", Mode);
                var result = await conn.QueryAsync<dynamic>("USP_SendEmail", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
