namespace BizsolETask_Api.Models
{
    public class TY_tblPendingTask
    {
        public int Code { get; set; }
        public int Status { get; set; }
        public int ResolutionTime { get; set; }
        public string ResolutiondDate { get; set; }
        public int ReAssign { get; set; } = 0;
        public int ResolvedBy { get; set; } = 0;
        public int UpdateBy { get; set; } = 0;
        public string Remarks { get; set; }
        public int ReasonMaster_Code { get; set; }
        public int UserMaster_Code { get; set; }
        
    }
}
