using ERPWizards.Models.Ledger;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models.Vouchers
{
    public enum VoucherType
    {
        Sales,
        Purchase,
        Receipt,
        Payment,
        Contra,
        Journal
    }
    public class Voucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoucherId { get; set; }
        public DateTime Date { get; set; }
        public VoucherType VoucherType { get; set; }
        public string VoucherNumber { get; set; }
        public GeneralLedger Ledger { get; set; }

        public IList<Models.Item.Items> ItemCollection { get; set; }

        public IList<GeneralLedger> BillLedgers { get; set; }
        public double baseAmount { get; set; }
        public double totalAmount { get; set; }

    }
}
