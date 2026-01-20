
using BizsolETask_Api.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BIZ_Alliera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushNotificationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PushNotificationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Request Models
        public class PlayerIdRequest
        {
            public string PlayerId { get; set; }
            public string UserId { get; set; }
            public string DeviceType { get; set; }
        }

        public class SendNotificationRequest
        {
            public int EmployeeMaster_Code { get; set; }
            public string SendTo { get; set; }
            public string Message { get; set; }
            public string Url { get; set; }
            public bool SendImmediate { get; set; } = true;
            public int? MasterTableCode { get; set; }
            public string MasterTableName { get; set; }
            public string PushNotificationsType { get; set; } = "Both";
            
        }

        public class SendToUsersRequest
        {
            public List<int> UserIds { get; set; }
            public string Message { get; set; }
            public string Title { get; set; }
            public string Url { get; set; }
            public bool SendImmediate { get; set; } = true;
            public int? MasterTableCode { get; set; }
            public string MasterTableName { get; set; }
        
        }

        // STEP 1: Save Player ID to EmployeeMaster table
        [HttpPost("SaveOneSignalPlayerId")]
        public IActionResult SaveOneSignalPlayerId([FromBody] PlayerIdRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.PlayerId))
                {
                    return BadRequest(new { success = false, message = "Player ID is required" });
                }

              
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);
               
                using (var connection = new SqlConnection(_bizsolESMSConnectionDetails.ConnectionSql))
                {
                    connection.Open();

                    // Check if user exists
                    var checkQuery = "SELECT COUNT(1) FROM EmployeeMaster WHERE Code = @UserId";
                    var userExists = connection.ExecuteScalar<int>(checkQuery, new { UserId = request.UserId });

                    if (userExists == 0)
                    {
                        return BadRequest(new { success = false, message = "User not found" });
                    }

                    // Update Player ID based on device type
                    var updateQuery = "";
                    if (request.DeviceType.ToLower() == "web")
                    {
                        updateQuery = "UPDATE EmployeeMaster SET PushNotificationsWebPlayerId = @PlayerId WHERE Code = @UserId";
                    }
                    else if (request.DeviceType.ToLower() == "android")
                    {
                        updateQuery = "UPDATE EmployeeMaster SET PushNotificationsAndroidPlayerId = @PlayerId WHERE Code = @UserId";
                    }

                    if (!string.IsNullOrEmpty(updateQuery))
                    {
                        connection.Execute(updateQuery, new { PlayerId = request.PlayerId, UserId = request.UserId });
                    }
                }

                return Ok(new
                {
                    success = true,
                    message = "Player ID saved successfully",
                    playerId = request.PlayerId,
                    userId = request.UserId
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error saving Player ID",
                    error = ex.Message
                });
            }
        }

        // STEP 2: Send notification to a single user (calls stored procedure)
        [HttpPost("SendNotificationToUser")]
        public IActionResult SendNotificationToUser([FromBody] SendNotificationRequest request)
        {
            try
            {
                // Get connection string from session
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);

                using (var connection = new SqlConnection(_bizsolESMSConnectionDetails.ConnectionSql))
                {
                    connection.Open();

                    // Call the stored procedure
                    var parameters = new DynamicParameters();
                    parameters.Add("@EmployeeMaster_Code", request.EmployeeMaster_Code);
                    parameters.Add("@SendTo", request.SendTo ?? "");
                    parameters.Add("@SendImmediate", request.SendImmediate ? "Y" : "N");
                    parameters.Add("@MasterTableCode", request.MasterTableCode ?? 0);
                    parameters.Add("@MasterTableName", request.MasterTableName ?? "");
                    parameters.Add("@PushNotificationsType", request.PushNotificationsType ?? "Web");
                    parameters.Add("@Msg", request.Message);
                    parameters.Add("@SendToAllUserRegistered", "N");

                    connection.Execute("USP_PushNotifications_InsertMsg",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                }

                return Ok(new
                {
                    success = true,
                    message = "Notification sent successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }
        [HttpPost("SendNotificationToUserAndroid")]
        public IActionResult SendNotificationToUserAndroid([FromBody] SendNotificationRequest request)
        {
            try
            {
                // Get connection string from session
                var _bizsolESMSConnectionDetails = CommonFunctions.InitializeERPConnection(HttpContext);

                using (var connection = new SqlConnection(_bizsolESMSConnectionDetails.ConnectionSql))
                {
                    connection.Open();

                    // Call the stored procedure
                    var parameters = new DynamicParameters();
                    parameters.Add("@EmployeeMaster_Code", request.EmployeeMaster_Code);
                    parameters.Add("@SendTo", request.SendTo ?? "");
                    parameters.Add("@SendImmediate", request.SendImmediate ? "Y" : "N");
                    parameters.Add("@MasterTableCode", request.MasterTableCode ?? 0);
                    parameters.Add("@MasterTableName", request.MasterTableName ?? "");
                    parameters.Add("@PushNotificationsType", request.PushNotificationsType ?? "Android");
                    parameters.Add("@Msg", request.Message);
                    parameters.Add("@SendToAllUserRegistered", "N");

                    connection.Execute("USP_PushNotifications_InsertMsg",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                }

                return Ok(new
                {
                    success = true,
                    message = "Notification sent successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

    }
}