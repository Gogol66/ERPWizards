using ERPWizards.Models;
using ERPWizards.Views;
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

namespace ERPWizards
{

    public partial class MainWindow : Window
    {

        public static string CompanyName = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            BindListBox();
        }
        public void BindListBox()
        {
            using (var context = new ERPDbContext())
            {
                this.CompanyList.ItemsSource = context.Companies.Select(s => s.CompanyName).ToList();
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            this.Hide();
            var modalWindow = new CreateorUpdateCompany();
            modalWindow.ShowDialog();
            e.Handled = true;
        }

        private void CompanyList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var listBox = sender as ListBox;
                if (listBox != null && listBox.SelectedItem != null)
                {
                    this.Hide();
                    //IsEdit = true;
                    CompanyName = listBox.SelectedItem.ToString();
                    var modalWindow = new Dashboard();
                    modalWindow.Show();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
