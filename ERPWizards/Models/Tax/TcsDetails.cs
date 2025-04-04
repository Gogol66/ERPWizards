using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models
{
    public class TcsDetails
    {
        [Key]
        public string TcsDetailsId { get; set; }
        public string CompanyId { get; set; }

        public string TanRegistrationNo { get; set; }
        public string TaxDeductionAndCollectionAccountNo { get; set; }
        public string CollectorType { get; set; }
        public string CollectorBranchDivision { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
