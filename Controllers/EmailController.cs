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
    }
}
