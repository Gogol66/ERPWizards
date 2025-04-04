using ERPWizards.Models;
using ERPWizards.Models.Countries;
using ERPWizards.Models.States;
using ERPWizards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ERPWizards.Views
{
    /// <summary>
    /// Interaction logic for CompanyCreation.xaml
    /// </summary>
    public class ComboBoxDataService
    {
        public List<string> GetStates()
        {
            using (var context = new ERPDbContext())
            {
                return context.States.OrderBy(s => s.StateName).Select(s => s.StateName).ToList();
            }
        }

        public List<string> GetCountries()
        {
            using (var context = new ERPDbContext())
            {
                return context.Countries.OrderBy(c => c.CountryName).Select(c => c.CountryName).ToList();
            }
        }
    }

    public partial class CreateorUpdateCompany : Window
    {
        private ComboBoxDataService dataService;
        public CreateorUpdateCompany()
        {
            InitializeComponent();
            this.Title = "Company Create";
            dataService = new ComboBoxDataService();
            this.StateComboBox.ItemsSource = dataService.GetStates();
            this.StateComboBox.SelectedIndex = 0;
            this.CountryComboBox.ItemsSource = dataService.GetCountries();
            this.CountryComboBox.SelectedIndex = 0;
            if (Dashboard.IsEdit == true)
            {
                this.NameTextBox.Text = MainWindow.CompanyName;
                PopulateControlsForEdit(MainWindow.CompanyName);
                this.SubmitButton.Content = "Update";
            }
            else
            {
                this.SubmitButton.Content = "Submit";
            }
        }
        private void PopulateControlsForEdit(string companyName)
        {
            using (var context = new ERPDbContext()) // Your DbContext
            {
                try
                {
                    // Fetch the company by CompanyName
                    var existingCompany = context.Companies.FirstOrDefault(c => c.CompanyName == companyName);

                    if (existingCompany == null)
                    {
                        MessageBox.Show("Company not found.");
                        return;
                    }

                    IdTextBox.Text = existingCompany.CompanyId;
                    NameTextBox.Text = existingCompany.CompanyName;
                    MailingNameTextBox.Text = existingCompany.CompanyMailingName;
                    CodeTextBox.Text = existingCompany.CompanyCode;
                    AddressTextBox.Text = existingCompany.CompanyAddress;
                    StateComboBox.Text = existingCompany.CompanyState; // Assuming StateComboBox contains state values
                    CountryComboBox.Text = existingCompany.Country; // Assuming CountryComboBox contains country values
                    PinCodeTextBox.Text = existingCompany.Pincode;
                    TelephoneTextBox.Text = existingCompany.TelephoneNo;
                    EmailTextBox.Text = existingCompany.Email;
                    WebsiteTextBox.Text = existingCompany.Website;
                    CurrencyTextBox.Text = existingCompany.BaseCurrencySymbol;
                    FinancialYearDatePicker.SelectedDate = existingCompany.FinancialYearBeginning;
                    BookBeginningDatePicker.SelectedDate = existingCompany.BookBeginning;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ERPDbContext()) // Use your DbContext
            {
                try
                {
                    // Check if the CompanyName exists in the database
                    string companyId = IdTextBox.Text.Trim(); // Ensure to read from your Name TextBox
                    var existingCompany = context.Companies.FirstOrDefault(c => c.CompanyId == companyId);

                    if (existingCompany != null)
                    {
                        // Update existing company
                        existingCompany.CompanyName = NameTextBox.Text;
                        existingCompany.CompanyMailingName = MailingNameTextBox.Text;
                        existingCompany.CompanyCode = CodeTextBox.Text;
                        existingCompany.CompanyAddress = AddressTextBox.Text;
                        existingCompany.CompanyState = StateComboBox.Text; // Assuming it's a ComboBox
                        existingCompany.Country = CountryComboBox.Text; // Assuming it's a ComboBox
                        existingCompany.Pincode = PinCodeTextBox.Text;
                        existingCompany.TelephoneNo = TelephoneTextBox.Text;
                        existingCompany.Email = EmailTextBox.Text;
                        existingCompany.Website = WebsiteTextBox.Text;
                        existingCompany.BaseCurrencySymbol = CurrencyTextBox.Text;
                        existingCompany.FinancialYearBeginning = FinancialYearDatePicker.SelectedDate ?? DateTime.Now;
                        existingCompany.BookBeginning = BookBeginningDatePicker.SelectedDate ?? DateTime.Now;

                        // Mark entity as modified
                        context.Entry(existingCompany).State = System.Data.Entity.EntityState.Modified;
                        System.Windows.MessageBox.Show("Company details updated successfully.");
                    }
                    else
                    {
                        // Create a new company
                        var newCompany = new Company
                        {
                            CompanyId = Guid.NewGuid().ToString(),
                            CompanyName = NameTextBox.Text,
                            CompanyMailingName = MailingNameTextBox.Text,
                            CompanyCode = CodeTextBox.Text,
                            CompanyAddress = AddressTextBox.Text,
                            CompanyState = StateComboBox.Text, // Assuming it's a ComboBox
                            Country = CountryComboBox.Text, // Assuming it's a ComboBox
                            Pincode = PinCodeTextBox.Text,
                            TelephoneNo = TelephoneTextBox.Text,
                            Email = EmailTextBox.Text,
                            Website = WebsiteTextBox.Text,
                            BaseCurrencySymbol = CurrencyTextBox.Text,
                            FinancialYearBeginning = FinancialYearDatePicker.SelectedDate ?? DateTime.Now,
                            BookBeginning = BookBeginningDatePicker.SelectedDate ?? DateTime.Now
                        };

                        context.Companies.Add(newCompany);
                        System.Windows.MessageBox.Show("Company details added successfully.");
                    }

                    // Save changes to the database
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            Dashboard.IsEdit = false;
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
