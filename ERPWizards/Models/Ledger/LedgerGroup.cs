using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERPWizards.Models.Ledger
{

    public class LedgerGroup
    {
        [Key]
        public int LedgerGroupId { get; set; } // Primary Key

        public string GroupName { get; set; }

        // Collection for ledgers in this group
        public virtual ICollection<GeneralLedger> Ledgers { get; set; }

        public LedgerGroup()
        {
            Ledgers = new HashSet<GeneralLedger>();
        }
    }
}
