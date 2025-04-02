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
        private readonly IStatusMaster _StatusMaster;
        private readonly IWorkTypeMaster _WorkTypeMaster;
        public MasterController(IUserModuleMaster IUserModuleMaster, IEmployeeMaster employeeMasterMaster, IStatusMaster statusMaster, IWorkTypeMaster workTypeMaster)
        {
            _UserModuleMaster = IUserModuleMaster;
            _EmployeeMasterMaster = employeeMasterMaster;
            _StatusMaster = statusMaster;
            _WorkTypeMaster = workTypeMaster;   
        }

        #region EmployeeMaster

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
        [HttpGet]
        [Route("ChangeEmployeeStatus")]
        public async Task<IActionResult> ChangeEmployeeStatus(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.ChangeEmployeeStatus(_bizsolESMSConnectionDetails, Code);
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
        [Route("GetExcelTemplate")]
        public async Task<IActionResult> GetExcelTemplate(string Mode,string WithData)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.GetExcelTemplate(_bizsolESMSConnectionDetails,Mode,WithData);
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
        [Route("ImportEmployeeMaster")]
        public async Task<IActionResult> ImportEmployeeMaster([FromBody] IEnumerable<TY_EmployeeMaster> EmployeeMaster, int UserMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.ImportEmployeeMaster(_bizsolESMSConnectionDetails, EmployeeMaster, UserMaster_Code);
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
        #endregion EmployeeMaster

        #region StatusMaster
        [HttpGet]
        [Route("GetStatusMasterList")]
        public async Task<IActionResult> GetStatusMasterList()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _StatusMaster.GetStatusMasterList(_bizsolESMSConnectionDetails);
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
        [Route("GetStatusMasterByCode")]
        public async Task<IActionResult> GetStatusMasterByCode(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _StatusMaster.GetStatusMasterByCode(_bizsolESMSConnectionDetails, Code);
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
        [Route("SaveStatusMaster")]
        public async Task<IActionResult> SaveStatusMaster([FromBody] TY_StatusMaster StatusMaster)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _StatusMaster.SaveStatusMaster(_bizsolESMSConnectionDetails, StatusMaster);
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
        [Route("DeleteStatusMaster")]
        public async Task<IActionResult> DeleteStatusMaster(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _StatusMaster.DeleteStatusMaster(_bizsolESMSConnectionDetails, Code);
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
        #endregion StatusMaster

        #region WorkTypeMaster
        [HttpGet]
        [Route("GetWorkTypeMasterList")]
        public async Task<IActionResult> GetWorkTypeMasterList()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _WorkTypeMaster.GetWorkTypeMasterList(_bizsolESMSConnectionDetails);
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
        [Route("GetWorkTypeMasterByCode")]
        public async Task<IActionResult> GetWorkTypeMasterByCode(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _WorkTypeMaster.GetWorkTypeMasterByCode(_bizsolESMSConnectionDetails, Code);
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
        [Route("SaveWorkTypeMaster")]
        public async Task<IActionResult> SaveWorkTypeMaster([FromBody] TY_WorkTypeMaster WorkTypeMaster)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _WorkTypeMaster.SaveWorkTypeMaster(_bizsolESMSConnectionDetails, WorkTypeMaster);
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
        [Route("DeleteWorkTypeMaster")]
        public async Task<IActionResult> DeleteWorkTypeMaster(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _WorkTypeMaster.DeleteWorkTypeMaster(_bizsolESMSConnectionDetails, Code);
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
        #endregion WorkTypeMaster
    }
}
