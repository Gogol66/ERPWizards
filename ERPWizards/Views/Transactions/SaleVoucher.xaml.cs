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


public class ItemsList
{
    public int SL { get; set; }
    public string Item { get; set; }
    public double Quantity { get; set; }
    public double Rate { get; set; }
    public double Amount { get; set; }
}
public class BillSundry
{
    public int SL { get; set; }
    public string Ledger { get; set; }
    public double Percenty { get; set; }    
    public double Amount { get; set; }
}

public class Party
{
    
    public string Ledger { get; set; }
    public string Type { get; set; }    
   
}

namespace ERPWizards.Views.Transactions
{
    /// <summary>
    /// Interaction logic for SaleVoucher.xaml
    /// </summary>
    public partial class SaleVoucher : Page
    {
        public SaleVoucher()
        {
            InitializeComponent();
            LoadData();
            this.VoucherDate.SelectedDate = DateTime.Now;
            this.VoucherSequenceNo.Text = $"PREFIT/{DateTime.Now.Year-1}-{DateTime.Now.Year}/01/";
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
                new Party{ Ledger = "INFOSYS CORPORATION LTD ",Type="Sundry debtors"},
                new Party{ Ledger = "Tata Consultancy Services LTD ", Type="Sundry debtors"},
                new Party{ Ledger = "MICROSOFT CORPORATION INDIA LTD ", Type = "Sundry debtors"},
                new Party{ Ledger = "GOOGLE  INDIA LTD ", Type = "Sundry debtors"},
                new Party{ Ledger = "ZOHO CORPORATION  LTD ", Type = "Sundry debtors"},
               
            };

            PartyDebtors.ItemsSource = sundryDebtorsParty.OrderBy(s => s.Ledger).Select(n => {
                    return $"{n.Ledger} - {n.Type}";
                });
            BillSundryGrid.ItemsSource = billSundry.OrderBy(b => b.SL);
            SaleGrid.ItemsSource = products;
        }


    }
}
