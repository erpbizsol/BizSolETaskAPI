namespace BizsolETask_Api.Models
{
    public class Vw_TimeSheet
    {
        public IEnumerable<TY_TimeSheetMaster> TimeSheetMaster { get; set; }
        public IEnumerable<TY_TimeSheetDetail> TimeSheetDetail { get; set; }
    }
}
