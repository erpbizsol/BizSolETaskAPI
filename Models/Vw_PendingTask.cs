namespace BizsolETask_Api.Models
{
    public class Vw_PendingTask
    {
        public IEnumerable<TY_Attachment> Attachment { get; set; }
        public IEnumerable<TY_tblPendingTask> PendingTask { get; set; }
    }
}
