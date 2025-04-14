using BizsolETask_Api.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BizsolETask_Api.Interface;

namespace BizsolETask_Api.Services
{
    public class TimeSheetService : ITimeSheet
    {
        public async Task<IEnumerable<dynamic>> GetClientList(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "CLIENTTYPE");
                var result = await conn.QueryAsync<dynamic>("USP_DropDown", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<IEnumerable<dynamic>> GetWorkTypeList(BizsolETaskConnectionString bizsolESMSConnectionDetails)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", "WORKTYPE");
                var result = await conn.QueryAsync<dynamic>("USP_DropDown", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public async Task<List<dynamic>> SaveTimeSheetMaster(BizsolETaskConnectionString bizsolESMSConnectionDetails, Vw_TimeSheet viewModel)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();

                // Extract master
                var master = viewModel.TimeSheetMastre;

                parameters.Add("Mode", "SAVEDATA");
                parameters.Add("Code", master.Code);
                parameters.Add("EmployeeName", master.EmployeeName);
                parameters.Add("Date", master.Date);
                parameters.Add("Remarks", master.Remarks);
                parameters.Add("UserMaster_Code", master.UserMaster_Code);

                // Prepare DataTable for TVP
                DataTable timeSheetTable = new DataTable();
                timeSheetTable.Columns.Add("ClientName", typeof(string));
                timeSheetTable.Columns.Add("FromHr", typeof(string));
                timeSheetTable.Columns.Add("ToHr", typeof(string));
                timeSheetTable.Columns.Add("TimeInMinutes", typeof(int));
                timeSheetTable.Columns.Add("WorkType", typeof(string));
                timeSheetTable.Columns.Add("Remarks1", typeof(string));

                foreach (var detail in viewModel.TimeSheetDetail)
                {
                    timeSheetTable.Rows.Add(
                        detail.ClientName,
                        detail.FromHr,
                        detail.ToHr,
                        detail.TimeinMinutes,
                        detail.WorkType,
                        detail.Remarks1
                    );
                }
                parameters.Add("TimeSheet", timeSheetTable.AsTableValuedParameter("TY_TimeSheetDetail"));
                var result = await conn.QueryAsync<dynamic>("USP_TimeSheetMasterNew", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

    }
}

