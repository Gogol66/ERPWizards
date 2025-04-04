using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERPWizards.Models.Settings;
namespace ERPWizards.Models.Item
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; } // Primary Key

        public string Name { get; set; }
        public string ItemCode { get; set; }
        public string UOM { get; set; }
        public string Group { get; set; }
        public string Category { get; set; }
        public string PartNo { get; set; }
        public bool GstApplicable { get; set; }
        public string HsnSacCode { get; set; }
        public string TaxableType { get; set; }
        public decimal IGST { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public string CessValuationType { get; set; }
        public decimal CessRate { get; set; }
        public bool ApplicableForReverseCharge { get; set; }
        public bool EligibleForTaxCredit { get; set; }
        public decimal Quantity { get; set; }

    }
}
