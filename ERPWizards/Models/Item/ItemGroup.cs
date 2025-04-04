using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPWizards.Models.Item
{
    public class ItemGroup
    {
        [Key]
        public int ItemGroupId { get; set; } // Primary Key

        public string GroupName { get; set; }

        // Self-referencing Foreign Key
        public int? ParentGroupId { get; set; } // Nullable for root groups
        [ForeignKey("ParentGroupId")]
        public virtual ItemGroup ParentGroup { get; set; } // Navigation Property

        // Collection for child groups
        public virtual ICollection<ItemGroup> ChildGroups { get; set; }

        public ItemGroup()
        {
            ChildGroups = new HashSet<ItemGroup>();
        }
    }

}
