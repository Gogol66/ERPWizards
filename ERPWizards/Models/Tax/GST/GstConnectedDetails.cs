using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models
{
    public class GstConnectedDetails
    {
        [Key]
        public string ConnectedDetailsId { get; set; } // Primary Key
        public string GSTPortalUsername { get; set; }
        public string ModeOfFilling { get; set; }
    }
}
