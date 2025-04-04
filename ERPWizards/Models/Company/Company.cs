using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models
{
    public class Company
    {
        [Key]
        public string CompanyId { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        public string CompanyMailingName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyState { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string BaseCurrencySymbol { get; set; }
        public DateTime FinancialYearBeginning { get; set; }
        public DateTime BookBeginning { get; set; }

        public ICollection<GstDetails> GstDetails { get; set; } = new List<GstDetails>();
        public ICollection<TdsDetails> TdsDetails { get; set; } = new List<TdsDetails>();
        public ICollection<TcsDetails> TcsDetails { get; set; } = new List<TcsDetails>();
    }
}
