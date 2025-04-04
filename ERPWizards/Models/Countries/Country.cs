using ERPWizards.Models.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models.Countries
{
    public class Country
    {
        [Key] // Primary Key for the Country table
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryShortName { get; set; }

        // Navigation property for related States
        public virtual ICollection<State> States { get; set; }
    }

}
