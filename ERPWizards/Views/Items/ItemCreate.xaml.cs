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

namespace ERPWizards.Views.Items
{
    /// <summary>
    /// Interaction logic for ItemCreate.xaml
    /// </summary>
    public partial class ItemCreate : Page
    {

        public List<string> GetGstApplicability()
        {
            List<string> Applicability = new List<string>();
            Applicability.Add("Applicable");
            Applicability.Add("Not Applicable");

            return Applicability.ToList();

        }
        private void SaveItemToDatabase()
        {
            try
            {
                using (var context = new ERPDbContext())
                {
                    // Create a new instance of Item model
                    Models.Item.Items newItem = new Models.Item.Items
                    {
                        Name = NameTextBox.Text, // Assume NameTextBox is the TextBox for "Name"
                        ItemCode = ItemCodeTextBox.Text, // TextBox for "Item Code"
                        UOM = UnitsComboBox.SelectedItem.ToString(), // ComboBox for "Unit"
                        Group = GroupTextBox.Text, // TextBox for "Group"
                        GstApplicable = GstApplicabilityComboBox.SelectedItem.ToString() == "Applicable", // ComboBox for GST applicability
                        HsnSacCode = HsnCodeTextBox.Text, // TextBox for HSN Code
                        IGST = decimal.Parse(IgstTextBox.Text), // TextBox for IGST
                        CGST = decimal.Parse(CgstTextBox.Text), // TextBox for CGST
                        SGST = decimal.Parse(SgstTextBox.Text), // TextBox for SGST
                        //CessRate = decimal.Parse(CessRateTextBox.Text), // TextBox for Cess Rate
                        ApplicableForReverseCharge = ReverseChargeCheckBox.IsChecked ?? false, // CheckBox for Reverse Charge
                        EligibleForTaxCredit = TaxCreditCheckBox.IsChecked ?? false, // CheckBox for Tax Credit
                        //SupplierId = int.Parse(SupplierIdTextBox.Text) // TextBox for Supplier ID
                    };

                    // Add the new item to the database
                    context.Items.Add(newItem);

                    // Save changes
                    context.SaveChanges();

                    // Show confirmation
                    MessageBox.Show("Item successfully added to the database!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                // Log exception and display error message
                Console.WriteLine($"Error while saving item: {ex.Message}");
                MessageBox.Show("Failed to add item. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<string> GetUnits()
        {
            using (var context = new ERPDbContext())
            {
                return context.UnitOfMeasurements.OrderBy(unit => unit.UnitName).Select(s => s.UnitName).ToList();
            }
        }
        public ItemCreate()
        {
            InitializeComponent();
            ValidateInputs();
            this.GstApplicabilityComboBox.ItemsSource = GetGstApplicability();
            this.GstApplicabilityComboBox.SelectedIndex = 0;
            this.UnitsComboBox.ItemsSource = GetUnits();
            this.UnitsComboBox.SelectedIndex = 0;
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(ItemCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(GroupTextBox.Text) ||
                UnitsComboBox.SelectedItem == null ||
                GstApplicabilityComboBox.SelectedItem == null ||
                !decimal.TryParse(IgstTextBox.Text, out _) ||
                !decimal.TryParse(CgstTextBox.Text, out _) ||
                !decimal.TryParse(SgstTextBox.Text, out _) ||
                !decimal.TryParse(CessRateTextBox.Text, out _) ||
                !int.TryParse(SupplierIdTextBox.Text, out _))
            {
                MessageBox.Show("Please ensure all fields are filled in correctly!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveItemToDatabase();
        }
    }
}
