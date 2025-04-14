namespace BizsolETask_Api.Models
{
    public class Vw_TimeSheet
    {
        //public List<TY_TimeSheetMastre> TimeSheetMastre { get; set; }
        public TY_TimeSheetMastre TimeSheetMastre { get; set; }
        public List<TY_TimeSheetDetail> TimeSheetDetail { get; set; }


    }
}
