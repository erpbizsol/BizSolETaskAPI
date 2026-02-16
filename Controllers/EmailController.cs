using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizsolETask_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmail _IEmail;
        public EmailController(IEmail IEmail)
        {
            _IEmail = IEmail;
        }
       
        [HttpGet]
        [Route("SenEmailMassage")]
        public async Task<IActionResult> SenEmailMassage(int Code,string Mode)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IEmail.SenEmailMassage(_bizsolESMSConnectionDetails, Code, Mode);
                    return Ok(result);
                }
                else
                {
                    return StatusCode(500, "Error To Fetch Connection String");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailRequest request)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null) 
                {
                    string Mode = string.IsNullOrWhiteSpace(request.Mode) ? "RATING" : request.Mode;
                    var result = await _IEmail.SendEmail(_bizsolESMSConnectionDetails, request.Codes, Mode);

                    if (result.Errors.Count == 0)
                        return Ok(new[] { new { Status = "Y", Msg = result.SentCount == request.Codes.Count ? "Email sent successfully." : $"Sent {result.SentCount} of {request.Codes.Count}." } });
                    if (result.SentCount > 0)
                        return Ok(new[] { new { Status = "Y", Msg = $"Sent {result.SentCount} of {request.Codes.Count}. " + string.Join(" ", result.Errors.Take(3)) } });
                    return StatusCode(500, new[] { new { Status = "N", Msg = result.Errors.Count > 0 ? result.Errors[0] : "Failed to send email." } });
                }
                else
                {
                    return StatusCode(500, "Error To Fetch Connection String");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
