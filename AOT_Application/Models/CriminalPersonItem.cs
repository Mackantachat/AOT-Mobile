using System;
using System.Collections.Generic;
using System.Text;

namespace AOT_Application.Models
{
    public class CriminalPersonItem
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
        public string PersonCode { get; set; }
        public DateTime? ViolationDate { get; set; }
        public DateTime? ArrestDate { get; set; }
        public string Description { get; set; }
        public string ViolationPlaceCode { get; set; }
        public string ResolveMethodCode { get; set; }
        public string ResolveMethod { get; set; }
        public string ResolveDetail { get; set; }
        public string ActuationCode { get; set; }
        public string ActuationResult { get; set; }
        public string PenaltyCode { get; set; }
        public string PenaltyDurationCode { get; set; }
        public decimal? FineAmount { get; set; }
        public string FinePayer { get; set; }
        public string FineReceiptNumber { get; set; }
        public string Remark { get; set; }
        public string Unit { get; set; }
        public DateTime? StartViolationDate { get; set; }
        public DateTime? EndViolationDate { get; set; }
        public string Behavior { get; set; }
        public string Supervisor { get; set; }
        public string License { get; set; }
        public string VehicleTypeCode { get; set; }
        public string VehicleBrandCode { get; set; }
        public string VehicleColorCode { get; set; }
        public string Place { get; set; }
        public string Point { get; set; }
        public string Property { get; set; }
        public string FlagReport { get; set; }
        public string Status { get; set; }

    }
}
