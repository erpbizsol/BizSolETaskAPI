using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IEmail
    {
        Task<IEnumerable<dynamic>> SenEmailMassage(BizsolETaskConnectionString bizsolESMSConnectionDetails, int Code, string Mode);
        Task<SendEmailResult> SendEmail(BizsolETaskConnectionString bizsolESMSConnectionDetails, List<int> codes, string Mode = "RATING");
    }
}
