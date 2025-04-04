using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models.Measurements
{
    public class UnitOfMeasurement
    {
        [Key]
        public int UnitID { get; set; }

        [Required]
        [MaxLength(50)]
        public string UnitName { get; set; }

        [MaxLength(10)]
        public string ShortName { get; set; }
    }
}
