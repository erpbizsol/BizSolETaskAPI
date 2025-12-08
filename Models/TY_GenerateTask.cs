using System.Data.SqlClient;
using System.Net.Sockets;

namespace BizsolETask_Api.Models
{
    public class TY_GenerateTask
    {
        public int Code { get; set; }
        public int TicketNo { get; set; } = 0;
        public int EmployeeMaster_Code { get; set; }
        public string? LogDate { get; set; } 
        public int ClientMaster_Code { get; set; }
        public int ModuleMaster_Code { get; set; }
        public int BizSolUserMaster_Code { get; set; }
        //public int SourceMaster_Code { get; set; }
        public string? Description { get; set; }
        public string? CommitedDate { get; set; } 
        public int WorkTypeMaster_Code { get; set; }
        public int StatusMaster_Code { get; set; }
        //public string? CommonColumn { get; set; }
        public string? Status { get; set; }
        public string? UpdateDate { get; set; }
        public int TicketTypeMaster_Code { get; set; }
       // public int CallTicketMaster_Code { get; set; }
        public int PriorityMaster_Code { get; set; }
        public string? Remarks { get; set; }
        public string? CustomerRemarks { get; set; }
        public int ReAssign_Code { get; set; }
        public int EstimatedTime { get; set; }
        public string? ProjectClient { get; set; }
        //public int Module { get; set; } = 0;
        public string? ContactNo { get; set; } = "";
        public string? ContactEMail { get; set; } = "";
        public int UserMaster_Code { get; set; }
        public int Source { get; set; } = 0;
        public string? PriorityText { get; set; } = "";
        public string? ModuleText { get; set; } = "";
        public string? SourceText { get; set; } = "";
        public string? RaisedBy { get; set; }
        public string? TicketTypeText { get; set; }
        public int TaskNatureMaster_Code { get; set; }
        public int Testedby_EmployeeMasterCode { get; set; }
    }
}

