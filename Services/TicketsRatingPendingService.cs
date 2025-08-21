using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class TicketsRatingPendingService: ITicketsRatingPending
    {
        public async Task<IEnumerable<dynamic>> GetTicketsRatingPending(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await conn.QueryAsync<dynamic>("USP_GetTicketsRatingPending", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveTicketsRating(BizsolETaskConnectionString bizsolESMSConnectionDetails, int CallTicketMaster_Code,int Star,string Remark,int UserMaster_Code)
        {
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("CallTicketMaster_Code", CallTicketMaster_Code);
                parameters.Add("Star", Star);
                parameters.Add("Remark", Remark);
                parameters.Add("UserMaster_Code", UserMaster_Code);
                var result = await conn.QueryAsync<dynamic>("USP_TicketsRatingMaster", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<dynamic> GetTicketsRatingByCode(BizsolETaskConnectionString bizsolESMSConnectionDetails, int CallTicketMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SHOWDATA");
                parameters.Add("CallTicketMaster_Code", CallTicketMaster_Code);
                var result = await conn.QueryAsync<dynamic>("USP_TicketsRatingMaster", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> TICKETSRATING(BizsolETaskConnectionString bizsolESMSConnectionDetails, int UserMaster_Code)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "TICKETSRATING");
                parameters.Add("UserMaster_Code", UserMaster_Code);
                var result = await conn.QueryAsync<dynamic>("USP_TicketsRatingMaster", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
