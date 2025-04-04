using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPWizards.Models.Item;

namespace ERPWizards.Models.Inventory
{
    public class GlobalStock
    {
        [Key]
        public int GlobalStockId { get; set; } // Primary Key

        public string ItemCode { get; set; }
        public int TotalStock { get; set; }

        // Foreign Key to Item
        public int ItemId { get; set; } // Foreign Key Property
        [ForeignKey("ItemId")]
        public virtual Items Item { get; set; } // Navigation Property

        public GlobalStock()
        {
            TotalStock = 0;
        }

        public void AddStock(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }

            TotalStock += quantity;
        }

        public void RemoveStock(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }

            if (quantity > TotalStock)
            {
                throw new InvalidOperationException("Insufficient stock.");
            }

            TotalStock -= quantity;
        }

        public int GetStock()
        {
            return TotalStock;
        }
    }
}
