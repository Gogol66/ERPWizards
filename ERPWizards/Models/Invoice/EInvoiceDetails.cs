using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models
{
    public class EInvoiceDetails
    {
        [Key]
        public string EInvoiceDetailsId { get; set; }
        public bool EInvoiceApplicable { get; set; }
    }
}
