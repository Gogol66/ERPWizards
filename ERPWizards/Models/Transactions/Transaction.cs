using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPWizards.Models.Ledger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERPWizards.Models.Vouchers;
namespace ERPWizards.Models.Transactions
{
    public enum TransactionType
    {
        Contra,
        CreditNote,
        DebitNote,
        Payment,
        Purchase,
        PaymentReceipt,
        ReversingJournal,
        Sale
    }

    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; } // Primary Key
        public TransactionType Type { get; set; }
        public string TypeString
        {
            get { return Type.ToString(); }
            set { Type = (TransactionType)Enum.Parse(typeof(TransactionType), value); }
        }
        public DateTime TransactionDate { get; set; }


        public int DebitLedgerId { get; set; } // Foreign Key Property
        public int VoucherId { get; set; }
        [ForeignKey("VoucherId")]
        public Voucher Voucher { get; set; } // Navigation Property

        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }

        public Transaction()
        {
            TransactionDate = DateTime.Now; // Default to current date
        }
    }
}
