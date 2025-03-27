using BizsolETask_Api.Interface;
using BizsolETask_Api.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BizsolETask_Api.Services
{
    public class UserModuleMasterService: IUserModuleMaster
    {
        public async Task<IEnumerable<dynamic>> GetUserModuleMasterList(BizsolETaskConnectionString bizsolESMSConnectionDetails,string UserType)
        {
            using (IDbConnection conn = new SqlConnection(bizsolESMSConnectionDetails.ConnectionSql))
            {
                DynamicParameters parameters = new DynamicParameters();
                string Query = $"SELECT Code, (case when ((mm.MenuName = 'Client Info') and (Select top 1 trim(FrmDisplayName) from FrmConfiguration(nolock) where FrmName = 'ClientMaster') = 'Department') then 'Department Info' else mm.MenuName End) MenuName, [URL], [Status], Icon, EmployeeType, CreatedDate FROM MenuMaster mm \r\nWHERE Status = 'Y' AND (EmployeeType = 'U' or EmployeeType ='{UserType.Trim()}')";
                var result = await conn.QueryAsync<dynamic>(Query, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
        }

    }
}
