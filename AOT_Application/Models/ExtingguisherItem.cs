using System;

namespace AOT_Application.Models
{
    public class ExtingguisherItem
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
        public long ReqPassVehicleId { get; set; }
        public string Status { get; set; }
    }

}