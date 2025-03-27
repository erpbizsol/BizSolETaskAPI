using System.Data.SqlClient;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;

namespace BizsolETask_Api.Models
{
    public static class CommonFunctions
    {
        public static BizsolETaskConnectionString InitializeERPConnection(HttpContext httpContext)
        {

            StringValues AutJsonKey = "";
            BizsolETaskConnectionString bizsolESMSConnectionDetails = new BizsolETaskConnectionString();

            if (httpContext.Request.Headers.TryGetValue("Auth-Key", out AutJsonKey))
            {
                bizsolESMSConnectionDetails = JsonConvert.DeserializeObject<BizsolETaskConnectionString>(AutJsonKey);
            }

            return bizsolESMSConnectionDetails;
        }
        public static async Task<string> EncryptPasswordAsync(string password)
        {
            StringBuilder encryptedPassword = new StringBuilder();
            foreach (char c in password)
            {
                encryptedPassword.Append(Convert.ToChar(Convert.ToInt32(c) + 10));
            }
            await Task.CompletedTask;
            return encryptedPassword.ToString();
        }
        public static async Task<string> DecryptPasswordAsync(string encryptedPassword)
        {
            StringBuilder decryptedPassword = new StringBuilder();
            foreach (char c in encryptedPassword)
            {
                decryptedPassword.Append(Convert.ToChar(Convert.ToInt32(c) - 10));
            }
            await Task.CompletedTask;
            return decryptedPassword.ToString();
        }
        public static List<DataTable> DataTableArrayExecuteSqlQueryWithParameter(string conStr, string queryString, Dictionary<string, object> Params, CommandType commandType = CommandType.Text)
        {
            List<DataTable> dt = new List<DataTable>();
            using (var connection = new SqlConnection(conStr))
            {
                var command = new SqlCommand(queryString, connection);
                command.CommandType = commandType;
                command.CommandTimeout = 0;
                connection.Open();
                if (Params != null)
                {
                    foreach (KeyValuePair<string, object> p in Params)
                    {
                        var dbParameter = command.CreateParameter();
                        dbParameter.ParameterName = p.Key;
                        dbParameter.Value = p.Value;
                        command.Parameters.Add(dbParameter);
                    }
                }
                using (var SqlDA = new SqlDataAdapter())
                {
                    DataSet ds = new DataSet();
                    SqlDA.SelectCommand = command;
                    SqlDA.Fill(ds);

                    foreach (var idt in ds.Tables)
                    {
                        dt.Add((DataTable)idt);
                    }
                    return dt;
                }
            }

        }
        public static List<Dictionary<string, object>> DatatableToDynamicList(DataTable dataTable)
        {
            return dataTable.AsEnumerable()
                            .Select(r => r.Table.Columns.Cast<DataColumn>()
                                         .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal]))
                                         .ToDictionary(z => z.Key, z => z.Value))
                                         .ToList();
        }
        public static async Task<IEnumerable<dynamic>> GetProcedureMappingSectionAsync(string sp_key)
        {
            var items = Enumerable.Empty<dynamic>();

            using (StreamReader r = new StreamReader("ProcedureMapping.json"))
            {
                string json = await r.ReadToEndAsync();
                JToken jToken = JToken.Parse(json);

                //var items = jToken["CRM_SP"].Where(x => x["ProcedureKey"].ToString() == "USP_AccountMaster12").Select(x => x["ProcedureName"]).ToList();
                items = jToken["CRM_SP"].Where(x => x["ProcedureKey"].ToString() == sp_key);

            }
            return items;

        }
        public static async Task<string> GetProcedureMappingSPNameAsync(string sp_key)
        {
            var items = Enumerable.Empty<dynamic>();
            string sp_name = "";
            List<string> strlist = new List<string>();
            using (StreamReader r = new StreamReader("ProcedureMapping.json"))
            {
                string json = await r.ReadToEndAsync();
                JToken jToken = JToken.Parse(json);

                //var items = jToken["CRM_SP"].Where(x => x["ProcedureKey"].ToString() == "USP_AccountMaster12").Select(x => x["ProcedureName"]).ToList();
                items = jToken["CRM_SP"].Where(x => x["ProcedureKey"].ToString() == sp_key);

            }

            foreach (var item in items)
            {
                foreach (var key in item)
                {
                    strlist.Add(key.ToString().Replace("\r\n", "").Replace("\"", "").Replace("]", "").Replace("[", ""));
                }
            }
            //var spkey = strlist[0].Split(':')[1].ToString();
            sp_name = strlist[1].Split(':')[1].ToString().Trim();
            //var sp_params = strlist[2].Split(':')[1].ToString();

            return sp_name;

        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> enumerable, bool trim = false)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get all public properties of the type
            PropertyInfo[] properties = typeof(T).GetProperties();

            //Create DataTable columns
            foreach (PropertyInfo property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            //Add data to the DataTable row by row
            foreach (T item in enumerable)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(item, null) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            if (trim)
                return dataTable;
            else
                return dataTable;
        }
        public static DataTable MapModelToProcedureTypeDataTable<T>(IEnumerable<T> Model, DataTable TY_STRUCTURE)
        {
            DataTable dtTY_STRUCTURE = TY_STRUCTURE;
            PropertyInfo[] properties = typeof(T).GetProperties();
            if (Model != null)
            {
                foreach (T item in Model)
                {
                    DataRow row = dtTY_STRUCTURE.NewRow();
                    foreach (DataColumn col in dtTY_STRUCTURE.Columns)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            if (col.ColumnName.ToUpper() == property.Name.ToUpper())
                            {
                                row[col.ColumnName] = property.GetValue(item, null) ?? DBNull.Value;
                                break;
                            }
                            else if (col.DataType == typeof(int) || col.DataType == typeof(float) || col.DataType == typeof(double) || col.DataType == typeof(decimal))
                            {
                                row[col.ColumnName] = 0;
                            }
                            else if (col.DataType == typeof(string))
                            {
                                row[col.ColumnName] = "";
                            }
                            else if (col.DataType == typeof(DateTime))
                            {
                                row[col.ColumnName] = System.DBNull.Value;
                            }

                        }
                    }

                    dtTY_STRUCTURE.Rows.Add(row);
                }
            }
            return dtTY_STRUCTURE;
        }
        public static string Encrypt(string inText, string key)
        {
            byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }
        public static string Decrypt(string inText, string key)
        {
            byte[] bytesBuff = Convert.FromBase64String(inText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }
            return inText;
        }
    }
}
