using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERPWizards.Models.Item
{
    public class ItemCategory
    {
        [Key]
        public int ItemCategoryId { get; set; } // Primary Key

        public string CategoryName { get; set; }

        // Collection for items in this category
        public virtual ICollection<Items> Items { get; set; }

        public ItemCategory()
        {
            Items = new HashSet<Items>();
        }
    }

}
