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

public class TransactionsRecord
{

    public int SL { get; set; }
    public DateTime Tranactiondate { get; set; }
    public string LedgerName { get; set; }
    public string TranactionType { get; set; }
    public double DebitAmount { get; set; }
    public double CreditAmount { get; set; }

}



namespace ERPWizards.Views.Transactions
{
    /// <summary>
    /// Interaction logic for DayBook.xaml
    /// </summary>
    public partial class DayBook : Page
    {
        public DayBook()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            List<TransactionsRecord> Daybook = new List<TransactionsRecord>
            {
                new TransactionsRecord{SL=1,Tranactiondate =  DateTime.Now,LedgerName = "INFOSYS CORPORATION LTD ",TranactionType="SALE",DebitAmount=145600,CreditAmount=0, },

                new TransactionsRecord{SL=2,Tranactiondate=DateTime.Now,LedgerName = "MICROSOFT CORPORATION LTD ",TranactionType="PURCHASE",DebitAmount=0,CreditAmount=24550, },
                new TransactionsRecord{SL=3,Tranactiondate=DateTime.Now,LedgerName = "TATA STEEL  LTD ",TranactionType="PURCHASE",DebitAmount=0,CreditAmount=1455900, },
                new TransactionsRecord{SL=4,Tranactiondate = DateTime.Now, LedgerName = "TATA STEEL  LTD ",TranactionType="PURCHASE",DebitAmount=0,CreditAmount=257900.44, },
                new TransactionsRecord{SL=5,Tranactiondate = DateTime.Now, LedgerName = "JINDAL STEEL  LTD ",TranactionType="PURCHASE",DebitAmount=0,CreditAmount=77600, },
                new TransactionsRecord{SL=6,Tranactiondate = DateTime.Now, LedgerName = "JSW STEEL  LTD ",TranactionType="PURCHASE",DebitAmount=0,CreditAmount=21650.77, },

                new TransactionsRecord{SL=7,Tranactiondate =  DateTime.Now,LedgerName = "TECHNO INDIA GROUP ",TranactionType="SALE",DebitAmount=15400,CreditAmount=0, },
                new TransactionsRecord{SL=8,Tranactiondate =  DateTime.Now,LedgerName = "METTLE TECH ",TranactionType="SALE",DebitAmount=570900,CreditAmount=0, },
                new TransactionsRecord{SL=9,Tranactiondate =  DateTime.Now,LedgerName = "RAZORPAY PVT LTD",TranactionType="SALE",DebitAmount=945745.44,CreditAmount=0, },
                new TransactionsRecord{SL=10,Tranactiondate =  DateTime.Now,LedgerName = "PhonePe ",TranactionType="SALE",DebitAmount=21400,CreditAmount=0, },


            };

            DayBookTransaction.ItemsSource = Daybook.OrderBy(o => o.SL);

        }
    }
}