using ERPWizards.Models.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models.States
{
    public class State
    {
        [Key] // Primary Key for the State table
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string StateShortName { get; set; }

        [ForeignKey("Country")] // Foreign Key to represent the relationship
        public string CountryCode { get; set; }

        // Navigation property to represent the relationship
        public virtual Country Country { get; set; }
    }

}
