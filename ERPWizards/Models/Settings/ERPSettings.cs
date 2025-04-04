using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ERPWizards.Models.Settings
{
    public class ERPSettings
    {
        [Key]
        public int SettingID { get; set; }

        [Required]
        [MaxLength(100)]
        public string SettingName { get; set; }

        [Required]
        [MaxLength(255)]
        public string SettingValue { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}
