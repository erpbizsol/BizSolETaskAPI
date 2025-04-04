using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public interface IEmployeeRatePerHourDetails
    {
        public abstract Task<IEnumerable<dynamic>> GetEmployeeRatePerHourDetails(BizsolETaskConnectionString BizsolETaskConnectionString,int EmployeeMaster_Code);
        public abstract Task<dynamic> DeleteEmployeeRatePerHourDetails(BizsolETaskConnectionString BizsolETaskConnectionString, int Code);
        public abstract Task<dynamic> SaveEmployeeRatePerHourDetails(BizsolETaskConnectionString BizsolETaskConnectionString, TY_EmployeeRatePerHourDetails EmployeeRatePerHourDetails);

    }
}
