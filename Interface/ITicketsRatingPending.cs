using BizsolETask_Api.Models;
using BizsolETask_Api.Services;

namespace BizsolETask_Api.Interface
{
    public interface ITicketsRatingPending
    {
        public abstract Task<IEnumerable<dynamic>> GetTicketsRatingPending(BizsolETaskConnectionString BizsolETaskConnectionString, string ReportType, string? FromDate ,string? ToDate);
        public abstract Task<dynamic> SaveTicketsRating(BizsolETaskConnectionString BizsolETaskConnectionString, TicketsRating ticketsRating);
        public abstract Task<dynamic> GetTicketsRatingByCode(BizsolETaskConnectionString BizsolETaskConnectionString, int CallTicketMaster_Code);
        public abstract Task<dynamic> TICKETSRATING(BizsolETaskConnectionString BizsolETaskConnectionString, int UserMastre_Code);
        Task<dynamic> SaveTicketsRatingAll(BizsolETaskConnectionString bizsolESMSConnectionDetails, List<TicketRatingModel> ratings);

    }
}
