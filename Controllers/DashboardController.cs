using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizsolETask_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IDashboard _IDashboard;
        public DashboardController(IDashboard IDashboard)
        {
            _IDashboard = IDashboard;

        }
      
        [HttpGet]
        [Route("GetEmployeeType")]
        public async Task<IActionResult> GetEmployeeType(string Mode,string FromDate, string ToDate,int UserMaster_Code, string? EmployeeMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IDashboard.GetEmployeeType(_bizsolESMSConnectionDetails, Mode, FromDate, ToDate, UserMaster_Code, EmployeeMaster_Code);
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
     
        [HttpGet]
        [Route("GetEmployeePending")]
        public async Task<IActionResult> GetEmployeePending(string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IDashboard.GetEmployeePending(_bizsolESMSConnectionDetails,Mode, FromDate, ToDate, UserMaster_Code, EmployeeMaster_Code);
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
        [HttpGet]
        [Route("GetClientPending")]
        public async Task<IActionResult> GetClientPending(string Mode, string FromDate, string ToDate, int UserMaster_Code, string? EmployeeMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IDashboard.GetClientPending(_bizsolESMSConnectionDetails, Mode, FromDate, ToDate, UserMaster_Code, EmployeeMaster_Code);
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
