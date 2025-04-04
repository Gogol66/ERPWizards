using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models
{
    public class EWayBillDetails
    {
        [Key]
        public string EWayBillDetailsId { get; set; } // Primary Key
        public bool EWayBillApplicable { get; set; }
        public DateTime ApplicableFrom { get; set; }
    }
}
