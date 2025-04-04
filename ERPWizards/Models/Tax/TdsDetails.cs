using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models
{
    public class TdsDetails
    {
        [Key]
        public string TdsDetailsId { get; set; }
        public string CompanyId { get; set; }

        public string TanRegistrationNo { get; set; }
        public string TaxDeductionAndCollectionAccountNo { get; set; }
        public string DeductionType { get; set; }
        public string DeductionBranchDivision { get; set; }


        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
