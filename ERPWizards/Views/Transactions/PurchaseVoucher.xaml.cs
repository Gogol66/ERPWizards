using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
namespace ERPWizards.Views.Transactions
{
    /// <summary>
    /// Interaction logic for PurchaseVoucher.xaml
    /// </summary>
    public partial class PurchaseVoucher : Page
    {
        public List<string> AllNames { get; set; }
        public ObservableCollection<string> FilteredNames { get; set; }

        public PurchaseVoucher()
        {
            InitializeComponent();
            LoadData();
            AllNames = new List<string>
    {
        "John Doe", "Jane Smith", "Michael Johnson", "Sarah Connor", "Chris Evans"
    };
            FilteredNames = new ObservableCollection<string>(AllNames);
            NameComboBox.ItemsSource = FilteredNames;

        }

        private void LoadData()
        {
            List<ItemsList> products = new List<ItemsList>
                {
                    new ItemsList {SL= 1,Item = "Iphone 15 Pro Max 512GB  Black",Quantity=10,Rate=154700,Amount= 1547000},
                    new ItemsList {SL= 2,Item = "Iphone 15 Pro  512GB  Black",Quantity=10,Rate=84500,Amount= 845000},
                    new ItemsList {SL= 3,Item = "Samsung Galaxy  ",Quantity=10,Rate=84500,Amount= 845000},
                    new ItemsList {SL= 4,Item = "Iphone 15 Pro Max 512GB  Black",Quantity=10,Rate=154700,Amount= 1547000},
                    new ItemsList {SL= 5,Item = "Iphone 15 Pro  512GB  Black",Quantity=10,Rate=84500,Amount= 845000},

                    new ItemsList {SL= 6,Item = "Samsung Galaxy  ",Quantity=10,Rate=84500,Amount= 845000},
                    new ItemsList {SL= 7,Item = "Iphone 15 Pro Max 512GB  Black",Quantity=10,Rate=154700,Amount= 1547000},
                    new ItemsList {SL= 8,Item = "Iphone 15 Pro  512GB  Black",Quantity=10,Rate=84500,Amount= 845000},
                    new ItemsList {SL= 9,Item = "Samsung Galaxy  ",Quantity=10,Rate=84500,Amount= 845000},
                    new ItemsList {SL= 10,Item = "Samsung Galaxy  ",Quantity=10,Rate=84500,Amount= 845000},
                    new ItemsList {SL= 11,Item = "Iphone 15 Pro Max 512GB  Black",Quantity=10,Rate=154700,Amount= 1547000},
                    new ItemsList {SL= 12,Item = "Iphone 15 Pro  512GB  Black",Quantity=10,Rate=84500,Amount= 845000},
                    new ItemsList {SL= 13,Item = "Samsung Galaxy  ",Quantity=10,Rate=84500,Amount= 845000},


                };

            List<BillSundry> billSundry = new List<BillSundry>
            {
                new BillSundry{SL = 1, Ledger = "WB SGST",Percenty=9,Amount=90},
                new BillSundry{SL = 2, Ledger = "WB SGST",Percenty=9,Amount=90},
                new BillSundry{SL = 3, Ledger = "Freight",Amount=1500},
                new BillSundry{SL = 4, Ledger = "Labour  Charges",Amount=600},
                new BillSundry{SL = 5, },
                new BillSundry{SL = 6, },
            };

            List<Party> sundryDebtorsParty = new List<Party>
            {
                new Party{ Ledger = "Oracle Corporation LTD",Type="sundry creditors"},
                new Party{ Ledger = "SAP Corporation LTD",Type="sundry creditors"},
                new Party{ Ledger = "OPEN AI Corporation LTD",Type="sundry creditors"},
                new Party{ Ledger = "Amazon Web Service LTD",Type="sundry creditors"},
                new Party{ Ledger = "Microsoft Azure LTD",Type="sundry creditors"},


            };

            PartyDebtors.ItemsSource = sundryDebtorsParty.OrderBy(s => s.Ledger).Select(n =>
            {
                return $"{n.Ledger} - {n.Type}";
            });
            BillSundryGrid.ItemsSource = billSundry.OrderBy(b => b.SL);
            PurchaseGrid.ItemsSource = products;
        }

        private void NameComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string searchText = NameComboBox.Text.ToLower();
            FilteredNames.Clear();
            foreach (var name in AllNames.Where(n => n.ToLower().Contains(searchText)))
            {
                FilteredNames.Add(name);
            }
        }
    }
}
