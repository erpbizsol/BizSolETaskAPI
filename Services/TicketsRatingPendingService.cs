using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    public class TicketRatingModel
    {
        public int CallTicketMaster_Code { get; set; }
        public int EmployeeMaster_Code { get; set; }
        public int Star { get; set; }
        public int UserMaster_Code { get; set; }
        public string RatingRemark { get; set; }
    }
      
    public class TicketsRatingPendingService : ITicketsRatingPending
    {
        public async Task<IEnumerable<dynamic>> GetTicketsRatingPending(BizsolETaskConnectionString bizsolESMSConnectionDetails, string ReportType, string? FromDate, string? ToDate)
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

        public async Task<dynamic> SaveTicketsRatingAll(BizsolETaskConnectionString bizsolESMSConnectionDetails, List<TicketRatingModel> ticketsRating)
        {
            using (SqlConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                await conn.OpenAsync();

                foreach (var item in ticketsRating)
                {
                    string query = @"
                IF EXISTS (SELECT 1 FROM TicketsRatingMaster 
                           WHERE CallTicketMaster_Code = @CallTicketMaster_Code 
                             AND CreatedBy = @EmployeeMaster_Code)
                BEGIN
                    UPDATE TicketsRatingMaster
                    SET Star = @Star, Remark = @RatingRemark, ModifiedOn = GETDATE()
                    WHERE CallTicketMaster_Code = @CallTicketMaster_Code 
                      AND CreatedBy = @EmployeeMaster_Code
                END
                ELSE
                BEGIN
                    INSERT INTO TicketsRatingMaster 
                        (CallTicketMaster_Code, CreatedBy, Star, Remark, CreatedOn)
                    VALUES (@CallTicketMaster_Code, @EmployeeMaster_Code, @Star, @RatingRemark, GETDATE())
                END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CallTicketMaster_Code", item.CallTicketMaster_Code);
                        cmd.Parameters.AddWithValue("@EmployeeMaster_Code", item.EmployeeMaster_Code);
                        cmd.Parameters.AddWithValue("@Star", item.Star);
                        cmd.Parameters.AddWithValue("@RatingRemark", item.RatingRemark ?? "");
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }

            // ✅ Always return something meaningful
            return new { Message = "Ratings saved successfully" };
        }



    }
}
