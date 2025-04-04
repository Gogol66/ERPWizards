using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.Models.Time

{
    public class FinancialYear
    {
        public int FinancialYearId { get; set; } // Primary Key
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDateWithinFinancialYear(DateTime date)
        {
            return date >= StartDate && date <= EndDate;
        }
    }

}
