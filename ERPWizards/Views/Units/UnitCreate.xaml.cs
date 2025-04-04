using ERPWizards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERPWizards.Views.Units
{
    /// <summary>
    /// Interaction logic for UnitCreate.xaml
    /// </summary>
    public partial class UnitCreate : Page
    {

        public List<string> GetUnitQuantityCode()
        {
            //     List<string> UnitQuantityCode = new List<string>();
            //UnitQuantityCode.Add("PCS-PICES");

            using (var context = new ERPDbContext())
            {
                return context.UnitOfMeasurements.OrderBy(unit => unit.UnitName).Select(s => s.UnitName).ToList();
            }
        }
        public UnitCreate()
        {
            InitializeComponent();
            this.UnitQuantityCode.ItemsSource = GetUnitQuantityCode();
            this.UnitQuantityCode.SelectedIndex = 0;
        }
    }
}
