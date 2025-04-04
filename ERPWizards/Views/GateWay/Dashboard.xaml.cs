using ERPWizards.Models;
using ERPWizards.Views.Items;
using ERPWizards.Views.Transactions;
using ERPWizards.Views.Units;
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
using System.Windows.Shapes;

namespace ERPWizards.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public static bool IsEdit = false;
        public Dashboard()
        {
            InitializeComponent();
            this.TopBarTitle.Text = MainWindow.CompanyName;
            this.Title = "ERP Wizards - " + MainWindow.CompanyName + "Gateways";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
            var modalWindow = new MainWindow();
            modalWindow.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewLedgerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new Ledger());
        }


        private void ItemMenuGroupItem_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ItemCreate());
        }

        private void UnitMenuGroupItem_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new UnitCreate());
        }

        private void SaleVoucherMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new SaleVoucher());
        }

        private void PurchaseVoucherMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new PurchaseVoucher());
        }

        private void DayBookMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new DayBook());
        }

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new Stock.StockSummary());
        }

        private void ModifyCompanyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                IsEdit = true;
                var modalWindow = new CreateorUpdateCompany();
                modalWindow.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CloseCompanyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new ERPDbContext())
                {
                    var company = context.Companies.Where(u => u.CompanyName == MainWindow.CompanyName).FirstOrDefault();
                    if (company != null)
                    {
                        context.Companies.Remove(company);
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Comapny has been deleted successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
