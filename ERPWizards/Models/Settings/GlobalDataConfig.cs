using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPWizards.Models.Settings
{
    public class GlobalDataConfig
    {
        [Key]
        public int ConfigID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ConfigName { get; set; }

        [Required]
        [MaxLength(255)]
        public string ConfigValue { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Key
        [ForeignKey("ERPSettings")]
        public int SettingID { get; set; }

        public ERPSettings ERPSettings { get; set; }
    }

}
