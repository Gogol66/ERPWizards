using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERPWizards.Models.Transactions;
namespace ERPWizards.Models.Ledger
{
    public class GeneralLedger
    {
        [Key]
        public int GeneralLedgerId { get; set; } // Primary Key

        public string LedgerName { get; set; }
        public string GroupOrType { get; set; }
        public string DynamicField { get; set; }

        [Column(TypeName = "decimal")]
        public decimal OpeningBalance { get; set; }

        [Required]
        [MaxLength(2)]
        public string CrDr { get; set; } // CR for Credit, DR for Debit

        // Foreign Key to LedgerGroup
        public int LedgerGroupId { get; set; } // Foreign Key Property
        public virtual LedgerGroup LedgerGroup { get; set; } // Navigation Property

        // Collections for transactions
        public virtual ICollection<Transaction> DebitTransactions { get; set; }
        public virtual ICollection<Transaction> CreditTransactions { get; set; }

        public GeneralLedger()
        {
            DebitTransactions = new HashSet<Transaction>();
            CreditTransactions = new HashSet<Transaction>();
        }
    }
}
