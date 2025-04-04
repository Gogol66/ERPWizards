using ERPWizards.Models.Ledger;
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
using System.Windows.Shapes;

namespace ERPWizards.Views
{
    public partial class Ledger : Page
    {
        private LedgerHead _currentLedger; // Holds the currently loaded ledger
        private ERPDbContext _dbContext;  // Database context

        public Ledger()
        {
            InitializeComponent();
            _dbContext = new ERPDbContext(); // Initialize the database context
            LoadLedger(); // Load ledger data
        }

        private void LoadLedger()
        {
            // Fetch the first ledger entry for demonstration purposes
            _currentLedger = _dbContext.LedgerHeads.FirstOrDefault();

            if (_currentLedger != null)
            {
                // Populate the fields with the ledger data
                LedgerNameTextBox.Text = _currentLedger.LedgerName;
                DescriptionTextBox.Text = _currentLedger.Description;
                OpeningBalanceTextBox.Text = _currentLedger.OpeningBalance.ToString("0.00");
                CreatedAtDatePicker.SelectedDate = _currentLedger.CreatedAt;
                UpdatedAtDatePicker.SelectedDate = _currentLedger.UpdatedAt;
            }
            else
            {
                MessageBox.Show("No ledger data found.");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentLedger == null)
            {
                _currentLedger = new LedgerHead(); // Create a new ledger
                _dbContext.LedgerHeads.Add(_currentLedger); // Add it to the database
            }

            try
            {
                // Update ledger properties
                _currentLedger.LedgerName = LedgerNameTextBox.Text;
                _currentLedger.Description = DescriptionTextBox.Text;
                _currentLedger.OpeningBalance = decimal.Parse(OpeningBalanceTextBox.Text);
                _currentLedger.CreatedAt = CreatedAtDatePicker.SelectedDate ?? DateTime.Now;
                _currentLedger.UpdatedAt = UpdatedAtDatePicker.SelectedDate ?? DateTime.Now;

                _dbContext.SaveChanges(); // Save changes to the database
                MessageBox.Show("Ledger saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the ledger: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
