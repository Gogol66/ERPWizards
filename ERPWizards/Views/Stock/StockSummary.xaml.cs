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

namespace ERPWizards.Views.Stock
{
    /// <summary>
    /// Interaction logic for StockSummary.xaml
    /// </summary>
    public partial class StockSummary : Page
    {
        public StockSummary()
        {
            InitializeComponent();
            BindItems();
        }
        public void BindItems()
        {
            using (var context = new ERPDbContext())
            {
                var items = context.Items.Where(u => u.ItemId != 0 && u.ItemId != int.MinValue).Select(u => u).ToList();
                StockSummaryGrid.ItemsSource = items;
            }
        }
    }
}
