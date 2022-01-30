using System;
using System.Collections.Generic;
using System.Text;

namespace AOT_Application.Models
{
    public class EventNotifyItem
    {
        public int Id { get; set; }
        public DateTime SystemDate { get; set; }
        public string SystemStaff { get; set; } 
        public DateTime? UpdateDate { get; set; }
        public string UpdateStaff { get; set; }
        public string EtlSystem { get; set; }
        public string EtlTable { get; set; }
        public string EtlField { get; set; }
        public string EtlValue { get; set; }
        public string Code { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public string TypeEmergencyCode { get; set; }
        public string Remark { get; set; }
        public string FlagPhone { get; set; }
        public string FlagDaily { get; set; }
        public string FlagVerbal { get; set; }
        public string FlagRapid { get; set; }
        public string FlagEmergency { get; set; }
        public string FlagBomb { get; set; }
        public string FlagAnalyze { get; set; }
        public string FlagEoc { get; set; }
        public string FlagAui { get; set; }
        public string Notifications { get; set; }
        public DateTime? NotificationsTime { get; set; }
        public string TmcCode { get; set; }
        public string ApCode { get; set; }
        public string DivisionCode { get; set; }
        public string CompanyCode { get; set; }
        public string Status { get; set; }
    }
}
