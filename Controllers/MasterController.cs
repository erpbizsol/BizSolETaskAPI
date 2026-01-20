using Bizsol_ESMS_API.Interface;
using Bizsol_ESMS_API.Model;
using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using BizsolETask_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using static BizsolETask_Api.Services.EmployeeMasterService;
using static BizsolETask_Api.Services.PendingTaskService;
using static Org.BouncyCastle.Math.EC.ECCurve;

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
        private readonly IClientMaster _ClientMaster;
        private readonly IEmployeeRatePerHourDetails _EmployeeRatePerHourDetails;
        private readonly ITimeSheet _ITimeSheet;
        private readonly IGenerateTask _IGenerateTask;
        private readonly IPendingTask _IPendingTask;
        private readonly IEmployeeAttandance _IEmployeeAttandance;
        private readonly ITicketsRatingPending _ITicketsRatingPending;
        private readonly IHolidayMaster _iHolidayMaster;
        private readonly ICurrentDate _ICurrentDate;
        private readonly ITaskNatureMaster _TaskNatureMaster;
        public MasterController(IUserModuleMaster IUserModuleMaster, IEmployeeMaster employeeMasterMaster, IStatusMaster statusMaster, IWorkTypeMaster workTypeMaster, IEmployeeRatePerHourDetails employeeRatePerHourDetails, IClientMaster clientMaster, ITimeSheet iTimeSheet, IGenerateTask iGenerateTask
        ,IPendingTask pendingTask,IEmployeeAttandance employeeAttandance, ITaskNatureMaster taskNatureMaster, ITicketsRatingPending _iTicketsRatingPending, IHolidayMaster _HolidayMaster, ICurrentDate _CurrentDate)
        {
           
            _UserModuleMaster = IUserModuleMaster;
            _EmployeeMasterMaster = employeeMasterMaster;
            _StatusMaster = statusMaster;
            _WorkTypeMaster = workTypeMaster;
            _EmployeeRatePerHourDetails = employeeRatePerHourDetails;
            _ClientMaster = clientMaster;
            _ITimeSheet = iTimeSheet;
            _IGenerateTask = iGenerateTask;
            _IPendingTask= pendingTask;
            _IEmployeeAttandance = employeeAttandance;
            _ITicketsRatingPending = _iTicketsRatingPending;
            _iHolidayMaster = _HolidayMaster;
            _ICurrentDate = _CurrentDate;
            _TaskNatureMaster = taskNatureMaster;
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
        [Route("GetEmployeeMaster")]
        public async Task<IActionResult> GetEmployeeMaster(string IsActive,string? EmployeeType = "")
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.GetEmployeeMaster(_bizsolESMSConnectionDetails,IsActive,EmployeeType);
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
        [HttpPost]
        [Route("ImportWorkTypeMaster")]
        public async Task<IActionResult> ImportWorkTypeMaster([FromBody] IEnumerable<TY_WorkTypeMaster> WorkTypeMaster, int UserMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _WorkTypeMaster.ImportWorkTypeMaster(_bizsolESMSConnectionDetails, WorkTypeMaster, UserMaster_Code);
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

        #region EmployeeRatePerHourDetails 

        [HttpGet]
        [Route("GetEmployeeRatePerHourDetails")]
        public async Task<IActionResult> GetEmployeeRatePerHourDetails(int EmployeeMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeRatePerHourDetails.GetEmployeeRatePerHourDetails(_bizsolESMSConnectionDetails, EmployeeMaster_Code);
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
        [Route("SaveEmployeeRatePerHourDetails")]
        public async Task<IActionResult> SaveEmployeeRatePerHourDetails([FromBody] TY_EmployeeRatePerHourDetails EmployeeRatePerHourDetails)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeRatePerHourDetails.SaveEmployeeRatePerHourDetails(_bizsolESMSConnectionDetails, EmployeeRatePerHourDetails);
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
        [Route("DeleteEmployeeRatePerHourDetails")]
        public async Task<IActionResult> DeleteEmployeeRatePerHourDetails(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeRatePerHourDetails.DeleteEmployeeRatePerHourDetails(_bizsolESMSConnectionDetails, Code);
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
        #endregion EmployeeRatePerHourDetails

        #region ClientMaster
        [HttpGet]
        [Route("GetClientMasterList")]
        public async Task<IActionResult> GetClientMasterList()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ClientMaster.GetClientMasterList(_bizsolESMSConnectionDetails);
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
        [Route("GetClientMasterByCode")]
        public async Task<IActionResult> GetClientMasterByCode(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ClientMaster.GetClientMasterByCode(_bizsolESMSConnectionDetails, Code);
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
        [Route("SaveClientMaster")]
        public async Task<IActionResult> SaveClientMaster([FromBody] TY_ClientMaster ClientMaster)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ClientMaster.SaveClientMaster(_bizsolESMSConnectionDetails, ClientMaster);
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
        [Route("DeleteClientMaster")]
        public async Task<IActionResult> DeleteClientMaster(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ClientMaster.DeleteClientMaster(_bizsolESMSConnectionDetails, Code);
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
        [Route("ImportClientMaster")]
        public async Task<IActionResult> ImportClientMaster([FromBody] IEnumerable<TY_ClientMaster> ClientMaster, int UserMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ClientMaster.ImportClientMaster(_bizsolESMSConnectionDetails, ClientMaster, UserMaster_Code);
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
        [Route("AssignClientsToEmployee")]
        public async Task<IActionResult> AssignClientsToEmployee([FromBody] IEnumerable<TY_AssignClient>  AssignClient)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ClientMaster.AssignClientsToEmployee(_bizsolESMSConnectionDetails, AssignClient);
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
        #endregion ClientMaster

        #region TimeSheet

        [HttpGet]
        [Route("GetClientList")]
        public async Task<IActionResult> GetClientList(int EmployeeName)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITimeSheet.GetClientList(_bizsolESMSConnectionDetails, EmployeeName);
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
        [Route("GetWorkTypeList")]
        public async Task<IActionResult> GetWorkTypeList()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITimeSheet.GetWorkTypeList(_bizsolESMSConnectionDetails);
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
        [Route("GetEmpDateList")]
        public async Task<IActionResult> GetEmpDateList(int EmployeeName, string WorkDate)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITimeSheet.GetEmpDateList(_bizsolESMSConnectionDetails,EmployeeName,WorkDate);
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
        [Route("SaveTimeSheetMaster")]
        public async Task<IActionResult> SaveTimeSheetMaster([FromBody] Vw_TimeSheet viewModel)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITimeSheet.SaveTimeSheetMaster(_bizsolESMSConnectionDetails, viewModel);
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
        [Route("Delete")]
        public async Task<IActionResult> Delete(int Code,int TimeSheetDetail_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITimeSheet.Delete(_bizsolESMSConnectionDetails, Code, TimeSheetDetail_Code);
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
        [Route("TimeSheetRemark")]
        public async Task<IActionResult> TimeSheetRemark(int Code, string Remark)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITimeSheet.TimeSheetRemark(_bizsolESMSConnectionDetails, Code, Remark);
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
        [Route("GetClientNameList")]
        public async Task<IActionResult> GetClientNameList()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITimeSheet.GetClientNameList(_bizsolESMSConnectionDetails);
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
        [Route("GetDate")]
        public async Task<IActionResult> GetDate(int EmployeeName)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITimeSheet.GetDate(_bizsolESMSConnectionDetails, EmployeeName);
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
        #endregion TimeSheet

        #region GenerateTask
        [HttpGet]
        [Route("GetTicketType")]
        public async Task<IActionResult> GetTicketType()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetTicketType(_bizsolESMSConnectionDetails);
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
        [Route("GetMenuName")]
        public async Task<IActionResult> GetMenuName()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetMenuName(_bizsolESMSConnectionDetails);
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
        [Route("GetTicketNo")]
        public async Task<IActionResult> GetTicketNo()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetTicketNo(_bizsolESMSConnectionDetails);
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
        [Route("GetTicketNolist")]
        public async Task<IActionResult> GetTicketNolist(int TickatN)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetTicketNolist(_bizsolESMSConnectionDetails, TickatN);
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
        [Route("GetPriorityDetails")]
        public async Task<IActionResult> GetPriorityDetails()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetPriorityDetails(_bizsolESMSConnectionDetails);
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
        [Route("GetClientMasterDetails")]
        public async Task<IActionResult> GetClientMasterDetails()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetClientMasterDetails(_bizsolESMSConnectionDetails);
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
        [Route("GetWorkTypes")]
        public async Task<IActionResult> GetWorkTypes()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetWorkTypes(_bizsolESMSConnectionDetails);
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
        [Route("GetAssigneds")]
        public async Task<IActionResult> GetAssigneds(int code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetAssigneds(_bizsolESMSConnectionDetails,code);
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
        [Route("GetAssignedss")]
        public async Task<IActionResult> GetAssignedss()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetAssignedss(_bizsolESMSConnectionDetails);
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
        [Route("SaveGenerateTaskTicket")]
        public async Task<IActionResult> SaveGenerateTaskTicket([FromBody] Vw_GenrateTask viewModel)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.SaveGenerateTaskTicket(_bizsolESMSConnectionDetails, viewModel);
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
        [Route("GetGenerateTaskTicketDate")]
        public async Task<IActionResult> GetGenerateTaskTicketDate(string EmployeeName, string showBy, string Status, string ticketNo)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetGenerateTaskTicketDate(_bizsolESMSConnectionDetails, EmployeeName, showBy, Status, ticketNo);
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
        [Route("GetGenerateTaskTicketByCode")]
        public async Task<IActionResult> GetGenerateTaskTicketByCode(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetGenerateTaskTicketByCode(_bizsolESMSConnectionDetails, Code);
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
        [Route("GetAttachment")]
        public async Task<IActionResult> GetAttachment(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetAttachment(_bizsolESMSConnectionDetails, Code);
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
        [Route("GetTicketsDetails")]
        public async Task<IActionResult> GetTicketsDetails(int TicketNo)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetTicketsDetails(_bizsolESMSConnectionDetails, TicketNo);
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
        [Route("GetWorksTimes")]
        public async Task<IActionResult> GetWorksTimes(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetWorksTimes(_bizsolESMSConnectionDetails, Code);
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
        [Route("DeleteGenerateTask")]
        public async Task<IActionResult> DeleteGenerateTask(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.DeleteGenerateTask(_bizsolESMSConnectionDetails, Code);
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
        [Route("GetEmployeeWiseClient")]
        public async Task<IActionResult> GetEmployeeWiseClient(string Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetEmployeeWiseClient(_bizsolESMSConnectionDetails,Code);
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
        [Route("DateWiseUserWiseTime")]
        public async Task<IActionResult> DateWiseUserWiseTime(string TickatNo)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.DateWiseUserWiseTime(_bizsolESMSConnectionDetails, TickatNo);
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
        [Route("GetGenerateTaskTicketDatePending")]
        public async Task<IActionResult> GetGenerateTaskTicketDatePending(string? EmployeeName, string Status, string ticketNo, string ReportType, string? FromDate, string? ToDate)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetGenerateTaskTicketDatePending(_bizsolESMSConnectionDetails, EmployeeName, Status, ticketNo,ReportType,FromDate,ToDate);
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
        [Route("GetTaskNatureMaster")]
        public async Task<IActionResult> GetTaskNatureMaster()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetTaskNatureMaster(_bizsolESMSConnectionDetails);
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
        [Route("GetEmployeeWiseUserName")]
        public async Task<IActionResult> GetEmployeeWiseUserName(string Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetEmployeeWiseUserName(_bizsolESMSConnectionDetails, Code);
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
        [Route("GetUserName")]
        public async Task<IActionResult> GetUserName(string UserName)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IGenerateTask.GetUserName(_bizsolESMSConnectionDetails, UserName);
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
        #endregion GenerateTask

        #region PendingTask
        [HttpGet]
        [Route("GetStatuss")]
        public async Task<IActionResult> GetStatuss()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IPendingTask.GetStatuss(_bizsolESMSConnectionDetails);
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
        [Route("GetReason")]
        public async Task<IActionResult> GetReason(int EmployeeCode)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IPendingTask.GetReason(_bizsolESMSConnectionDetails, EmployeeCode);
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
        [Route("GetStatusType")]
        public async Task<IActionResult> GetStatusType(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IPendingTask.GetStatusType(_bizsolESMSConnectionDetails,Code);
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
        [Route("SavePendingTask")]
        public async Task<IActionResult> SavePendingTask([FromBody] Vw_PendingTask pendingTask)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IPendingTask.SavePendingTask(_bizsolESMSConnectionDetails, pendingTask);
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
        [Route("GetPendingTaskReport")]
        public async Task<IActionResult> GetPendingTaskReport(int Code,string Status)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IPendingTask.GetPendingTaskReport(_bizsolESMSConnectionDetails, Code,Status);
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
        [Route("GetCallTicketMasterPlanningDetails")]
        public async Task<IActionResult> GetCallTicketMasterPlanningDetails(int EmployeeCode, string Year, int WeekNo)
        {
            try
            {
                var connDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (connDetails.ConnectionSql != null)
                {
                    var result = await _IPendingTask.GetCallTicketMasterPlanningDetails(connDetails, EmployeeCode, Year, WeekNo);
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
        [Route("UpdateCallTicketMasterPlanning")]
        public async Task<IActionResult> UpdateCallTicketMasterPlanning([FromBody] UpdateCallTicketPlanningRequest req)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IPendingTask.UpdateCallTicketMasterPlanning(_bizsolESMSConnectionDetails, req);
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
        #endregion PendingTask

        #region  EmployeeAttandance

        [HttpGet]
        [Route("GetEmployeeIdCard")]
        public async Task<IActionResult> GetEmployeeIdCard()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IEmployeeAttandance.GetEmployeeIdCard(_bizsolESMSConnectionDetails);
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
        [Route("GetCardwiseEmployeeName")]
        public async Task<IActionResult> GetCardwiseEmployeeName(string CardCode)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IEmployeeAttandance.GetCardwiseEmployeeName(_bizsolESMSConnectionDetails, CardCode);
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
        [Route("GetEmployeeAttandance")]
        public async Task<IActionResult> GetEmployeeAttandance(string EmployeeCode, string Date)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IEmployeeAttandance.GetEmployeeAttandance(_bizsolESMSConnectionDetails, EmployeeCode, Date);
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
        [Route("SaveEmployeeAttandance")]
        public async Task<IActionResult> SaveEmployeeAttandance([FromBody] TY_EmployeeAttandance EmployeeAttandance)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IEmployeeAttandance.SaveEmployeeAttandance(_bizsolESMSConnectionDetails, EmployeeAttandance);
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
        [Route("SaveEmployeeStatus")]
        public async Task<IActionResult> SaveEmployeeStatus(string? EmployeeCode, string? Date, string? Status, int UserMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _IEmployeeAttandance.SaveEmployeeStatus(_bizsolESMSConnectionDetails,EmployeeCode, Date, Status,UserMaster_Code);
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
        #endregion EmployeeAttandance

        #region TicketsRatingPending
        [HttpGet]
        [Route("GetTicketsRatingPending")]
        public async Task<IActionResult> GetTicketsRatingPending(string ReportType, string? FromDate, string? ToDate)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITicketsRatingPending.GetTicketsRatingPending(_bizsolESMSConnectionDetails, ReportType, FromDate,ToDate);
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
        [Route("SaveTicketsRating")]
        public async Task<IActionResult> SaveTicketsRating(TicketsRating ticketsRating)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITicketsRatingPending.SaveTicketsRating(_bizsolESMSConnectionDetails, ticketsRating);
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
        [Route("GetTicketsRatingByCode")]
        public async Task<IActionResult> GetTicketsRatingByCode(int CallTicketMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITicketsRatingPending.GetTicketsRatingByCode(_bizsolESMSConnectionDetails, CallTicketMaster_Code);
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
        [Route("TICKETSRATING")]
        public async Task<IActionResult> TICKETSRATING(int UserMaster_Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITicketsRatingPending.TICKETSRATING(_bizsolESMSConnectionDetails, UserMaster_Code);
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
     
        [HttpPost("SaveTicketsRatingAll")]
        public async Task<IActionResult> SaveTicketsRatingAll([FromBody] List<TicketRatingModel> ratings)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _ITicketsRatingPending.SaveTicketsRatingAll(_bizsolESMSConnectionDetails, ratings);
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


        #endregion TicketsRatingPending

        #region SaveConfig
        [HttpPost]
        [Route("SaveConfigMaster")]
        public async Task<IActionResult> SaveConfigMaster([FromBody] ConfigMasterRequest Configrequest)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.SaveConfigMaster(_bizsolESMSConnectionDetails, Configrequest);
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
        [Route("ShowConfig")]
        public async Task<IActionResult> ShowConfig()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _EmployeeMasterMaster.ShowConfig(_bizsolESMSConnectionDetails);
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
        #endregion SaveConfig

        #region HolidayMaster
        [HttpPost]
        [Route("SaveHolidayMaster")]
        public async Task<IActionResult> SaveHolidayMaster([FromBody] TY_HolidayMaster HolidayMaster)
        {

            try
            {
                var BizsolETaskConnectionString = CommonFunctions.InitializeERPConnection(HttpContext);
                if (BizsolETaskConnectionString.ConnectionSql != null)
                {
                    var result = await _iHolidayMaster.SaveHolidayMaster(BizsolETaskConnectionString, HolidayMaster);
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
        [Route("GetHolidayMasterList")]
        public async Task<IActionResult> GetHolidayMaster()
        {
            try
            {
                var BizsolETaskConnectionString = CommonFunctions.InitializeERPConnection(HttpContext);
                if (BizsolETaskConnectionString.ConnectionSql != null)
                {
                    var result = await _iHolidayMaster.GetHolidayMasterList(BizsolETaskConnectionString);
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
        [Route("GetHolidayMasterByCode")]
        public async Task<IActionResult> GetHolidayMasterByCode(int Code)
        {

            try
            {
                var BizsolETaskConnectionString = CommonFunctions.InitializeERPConnection(HttpContext);
                if (BizsolETaskConnectionString.ConnectionSql != null)
                {
                    var result = await _iHolidayMaster.GetHolidayMasterByCode(BizsolETaskConnectionString, Code);
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
        [Route("DeleteHolidayMaster")]
        public async Task<IActionResult> DeleteHolidayMaster(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _iHolidayMaster.DeleteHolidayMaster(_bizsolESMSConnectionDetails, Code);
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

        #endregion HolidayMaster

        #region CurrentDate

        [HttpGet]
        [Route("GetCurrentDate")]
        public async Task<IActionResult> GetCurrentDate()
        {
            try
            {
                var bizsolETaskConnectionString = CommonFunctions.InitializeERPConnection(HttpContext);
                if (bizsolETaskConnectionString.ConnectionSql != null)
                {
                    var result = await _ICurrentDate.GetCurrentDate(bizsolETaskConnectionString);
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

        #endregion CurrentDate

        #region TaskNatureMaster
        [HttpGet]
        [Route("GetTaskNatureMasterList")]
        public async Task<IActionResult> GetTaskNatureMasterList()
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _TaskNatureMaster.GetTaskNatureMasterList(_bizsolESMSConnectionDetails);
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
        [Route("GetTaskNatureMasterByCode")]
        public async Task<IActionResult> GetTaskNatureMasterByCode(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _TaskNatureMaster.GetTaskNatureMasterByCode(_bizsolESMSConnectionDetails, Code);
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
        [Route("SaveTaskNatureMaster")]
        public async Task<IActionResult> SaveTaskNatureMaster([FromBody] TY_TaskNatureMaster TaskNatureMaster)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _TaskNatureMaster.SaveTaskNatureMaster(_bizsolESMSConnectionDetails, TaskNatureMaster);
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
        [Route("DeleteTaskNatureMaster")]
        public async Task<IActionResult> DeleteTaskNatureMaster(int Code)
        {
            try
            {
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
                if (_bizsolESMSConnectionDetails.ConnectionSql != null)
                {
                    var result = await _TaskNatureMaster.DeleteTaskNatureMaster(_bizsolESMSConnectionDetails, Code);
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
        #endregion TaskNatureMaster

    }
}
