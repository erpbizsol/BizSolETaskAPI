using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizsolETask_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IUserModuleMaster _UserModuleMaster;
        private readonly IEmployeeMaster _EmployeeMasterMaster;
        public MasterController(IUserModuleMaster IUserModuleMaster, IEmployeeMaster employeeMasterMaster)
        {
            _UserModuleMaster = IUserModuleMaster;
            _EmployeeMasterMaster = employeeMasterMaster;   
        }
        [HttpGet]
        [Route("GetUserModuleMasterList")]
        public async Task<IActionResult> GetUserModuleMasterList(string UserType)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _UserModuleMaster.GetUserModuleMasterList(_bizsolESMSConnectionDetails,UserType);
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
        [Route("GetEmployeeMasterList")]
        public async Task<IActionResult> GetEmployeeMasterList()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.GetEmployeeMasterList(_bizsolESMSConnectionDetails);
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
        [Route("GetEmployeeMasterByCode")]
        public async Task<IActionResult> GetEmployeeMasterByCode(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.GetEmployeeMasterByCode(_bizsolESMSConnectionDetails,Code);
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
        [HttpPost]
        [Route("SaveEmployeeMaster")]
        public async Task<IActionResult> SaveEmployeeMaster([FromBody] TY_EmployeeMaster EmployeeMaster)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.SaveEmployeeMaster(_bizsolESMSConnectionDetails, EmployeeMaster);
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
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] TY_EmployeeMaster EmployeeMaster)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.ChangePassword(_bizsolESMSConnectionDetails, EmployeeMaster);
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
