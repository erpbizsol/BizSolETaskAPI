using BizsolETask_Api.Models;

namespace BizsolETask_Api.Interface
{
    public class Vw_GenrateTask
    {
    
            public IEnumerable<TY_Attachment> Attachment { get; set; }
            public IEnumerable<TY_GenerateTask> GenerateTask { get; set; }
        
    }
}
