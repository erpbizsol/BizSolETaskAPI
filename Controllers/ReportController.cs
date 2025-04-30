using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizsolETask_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
  
        private readonly IReport _IReport;
        public ReportController(IReport iReport)
        {
            _IReport = iReport;
        }
        [HttpGet]
        [Route("GetTimeSheetReport")]
        public async Task<IActionResult> GetTimeSheetReport(string FromDate, string ToDate,string ClientMaster_Code ="", string WorkTypeMaster_Code = "", string EmployeeMaster_Code = "",string ReportType="")
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IReport.GetTimeSheetReport(_bizsolESMSConnectionDetails,FromDate,ToDate,ClientMaster_Code,
                     WorkTypeMaster_Code,EmployeeMaster_Code,ReportType);
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
        [Route("GetClientType")]
        public async Task<IActionResult> GetClientType(string FromDate, string ToDate)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IReport.GetClientType(_bizsolESMSConnectionDetails, FromDate, ToDate);
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
        [Route("GetWorkType")]
        public async Task<IActionResult> GetWorkType(string FromDate, string ToDate)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IReport.GetWorkType(_bizsolESMSConnectionDetails, FromDate, ToDate);
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
        [Route("GetEmployeeType")]
        public async Task<IActionResult> GetEmployeeType(string FromDate, string ToDate)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IReport.GetEmployeeType(_bizsolESMSConnectionDetails, FromDate, ToDate);
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
