using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BizsolETask_Api.Services
{

    public class TicketsRating
    {
        public int CallTicketMaster_Code { get; set; }
        public int Star { get; set; }
        public string Remark { get; set; }
        public int EmployeeCode { get; set; }
        public int UserMaster_Code { get; set; }
       
    }
    public class TicketsRatingPendingService: ITicketsRatingPending
    {
        public async Task<IEnumerable<dynamic>> GetTicketsRatingPending(BizsolETaskConnectionString bizsolESMSConnectionDetails,string ReportType,string? FromDate, string? ToDate)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ReportType", ReportType);
                parameters.Add("FromDate", FromDate);
                parameters.Add("ToDate", ToDate);
                var result = await conn.QueryAsync<dynamic>("USP_GetTicketsRatingPending", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<dynamic> SaveTicketsRating(BizsolETaskConnectionString bizsolESMSConnectionDetails, TicketsRating ticketsRating)
        {
            using (IDbConnection conn = new
            SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("CallTicketMaster_Code", ticketsRating.CallTicketMaster_Code);
                parameters.Add("Star", ticketsRating.Star);
                parameters.Add("Remark", ticketsRating.Remark);
                parameters.Add("EmployeeCode", ticketsRating.EmployeeCode);
                parameters.Add("UserMaster_Code", ticketsRating.UserMaster_Code);
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
