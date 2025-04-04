using ERPWizards.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWizards.ViewModels
{
    // ViewModel for CRUD Operations
    public class CompanyViewModel : INotifyPropertyChanged
    {
        // Basic Company Information
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyMailingName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyState { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string BaseCurrencySymbol { get; set; }
        public DateTime FinancialYearBeginning { get; set; }
        public DateTime BookBeginning { get; set; }

        // Related Details
        public List<string> GstDetails { get; set; } = new List<string>();
        public List<string> TdsDetails { get; set; } = new List<string>();
        public List<string> TcsDetails { get; set; } = new List<string>();

        // CRUD-Specific Properties
        public string Operation { get; set; } // "Create", "Read", "Update", "Delete"
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        // Timestamps for tracking
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
    }

    // Utility class for CRUD Operations
    public static class CompanyCRUDOperations
    {
        // Example method to map ViewModel to Entity
        public static Company MapToEntity(CompanyViewModel viewModel)
        {
            return new Company
            {
                CompanyId = viewModel.CompanyId,
                CompanyName = viewModel.CompanyName,
                CompanyMailingName = viewModel.CompanyMailingName,
                CompanyCode = viewModel.CompanyCode,
                CompanyAddress = viewModel.CompanyAddress,
                CompanyState = viewModel.CompanyState,
                Country = viewModel.Country,
                Pincode = viewModel.Pincode,
                TelephoneNo = viewModel.TelephoneNo,
                MobileNo = viewModel.MobileNo,
                Email = viewModel.Email,
                Website = viewModel.Website,
                BaseCurrencySymbol = viewModel.BaseCurrencySymbol,
                FinancialYearBeginning = viewModel.FinancialYearBeginning,
                BookBeginning = viewModel.BookBeginning,
                //GstDetails = viewModel.GstDetails.Select(g => new GstDetails { Detail = g }).ToList(),
                //TdsDetails = viewModel.TdsDetails.Select(t => new TdsDetails { Detail = t }).ToList(),
                //TcsDetails = viewModel.TcsDetails.Select(t => new TcsDetails { Detail = t }).ToList()
            };
        }

        // Example method to map Entity to ViewModel
        public static CompanyViewModel MapToViewModel(Company entity)
        {
            return new CompanyViewModel
            {
                CompanyId = entity.CompanyId,
                CompanyName = entity.CompanyName,
                CompanyMailingName = entity.CompanyMailingName,
                CompanyCode = entity.CompanyCode,
                CompanyAddress = entity.CompanyAddress,
                CompanyState = entity.CompanyState,
                Country = entity.Country,
                Pincode = entity.Pincode,
                TelephoneNo = entity.TelephoneNo,
                MobileNo = entity.MobileNo,
                Email = entity.Email,
                Website = entity.Website,
                BaseCurrencySymbol = entity.BaseCurrencySymbol,
                FinancialYearBeginning = entity.FinancialYearBeginning,
                BookBeginning = entity.BookBeginning,
                //GstDetails = entity.GstDetails.Select(g => g.Detail).ToList(),
                //TdsDetails = entity.TdsDetails.Select(t => t.Detail).ToList(),
                //TcsDetails = entity.TcsDetails.Select(t => t.Detail).ToList(),
                CreatedDate = DateTime.Now, // Set appropriately
                ModifiedDate = DateTime.Now, // Set appropriately
                IsSuccess = true,
                Message = "Mapped successfully"
            };
        }

        // CRUD Examples
        public static string CreateCompany(CompanyViewModel viewModel)
        {
            try
            {
                Company newCompany = MapToEntity(viewModel);
                // Add logic to save to database
                return "Company created successfully!";
            }
            catch (Exception ex)
            {
                return $"Error in creating company: {ex.Message}";
            }
        }

        public static CompanyViewModel ReadCompany(string companyId)
        {
            try
            {
                // Fetch Company entity from database using companyId
                Company company = new Company(); // Replace with actual retrieval
                return MapToViewModel(company);
            }
            catch (Exception ex)
            {
                return new CompanyViewModel
                {
                    IsSuccess = false,
                    Message = $"Error in reading company: {ex.Message}"
                };
            }
        }

        public static string UpdateCompany(CompanyViewModel viewModel)
        {
            try
            {
                Company updatedCompany = MapToEntity(viewModel);
                // Add logic to update database
                return "Company updated successfully!";
            }
            catch (Exception ex)
            {
                return $"Error in updating company: {ex.Message}";
            }
        }

        public static string DeleteCompany(string companyId)
        {
            try
            {
                // Add logic to delete from database using companyId
                return "Company deleted successfully!";
            }
            catch (Exception ex)
            {
                return $"Error in deleting company: {ex.Message}";
            }
        }
    }

}
