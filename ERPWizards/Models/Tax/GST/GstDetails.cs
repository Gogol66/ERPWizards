using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models
{
    public class GstDetails
    {
        [Key]
        public string GstDetailsId { get; set; }
        public string CompanyId { get; set; }

        public string State { get; set; }
        public string RegistrationType { get; set; }
        public bool AssesseeOfOtherTerritory { get; set; }
        public string GSTINUIN { get; set; }
        public string PeriodicityOfGSTR1 { get; set; }
        public bool EInvoiceApplicable { get; set; }

        public GstConnectedDetails ConnectedDetails { get; set; }
        public EInvoiceDetails EInvoiceDetails { get; set; }
        public EWayBillDetails EWayBillDetails { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
