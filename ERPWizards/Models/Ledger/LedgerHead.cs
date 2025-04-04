using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ERPWizards.Models.Ledger
{

    public class LedgerHead
    {
        [Key]
        public int LedgerHeadID { get; set; }

        [Required]
        [MaxLength(100)]
        public string LedgerName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public decimal OpeningBalance { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties (optional)
        // public ICollection<LedgerEntry> LedgerEntries { get; set; }
    }

}
