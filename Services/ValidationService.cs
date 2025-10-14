using campus_buddy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace campus_buddy.Services
{
    // Service for validating user inputs
    // Demonstrates: Input validation requirement 

    public class ValidationService
    {
        //Validates a lost or found item before saving

        public ValidationResult ValidateItem(Item item)
        {
            var result = new ValidationResult { IsValid = true };

            // Validate Title
            if (string.IsNullOrWhiteSpace(item.Title))
            {
                result.IsValid = false;
                result.Errors.Add("Title is required.");
            }
            else if (item.Title.Length < 3)
            {
                result.IsValid = false;
                result.Errors.Add("Title must be at least 3 characters long.");
            }
            else if (item.Title.Length > 100)
            {
                result.IsValid = false;
                result.Errors.Add("Title must not exceed 100 characters.");
            }

            // Validate Description
            if (string.IsNullOrWhiteSpace(item.Description))
            {
                result.IsValid = false;
                result.Errors.Add("Description is required.");
            }
            else if (item.Description.Length < 10)
            {
                result.IsValid = false;
                result.Errors.Add("Description must be at least 10 characters long.");
            }
            else if (item.Description.Length > 500)
            {
                result.IsValid = false;
                result.Errors.Add("Description must not exceed 500 characters.");
            }

            // Validate Location
            if (string.IsNullOrWhiteSpace(item.Location))
            {
                result.IsValid = false;
                result.Errors.Add("Location is required.");
            }
            else if (item.Location.Length < 3)
            {
                result.IsValid = false;
                result.Errors.Add("Location must be at least 3 characters long.");
            }

            // Validate Reporter Name
            if (string.IsNullOrWhiteSpace(item.ReporterName))
            {
                result.IsValid = false;
                result.Errors.Add("Reporter name is required.");
            }
            else if (item.ReporterName.Length < 2)
            {
                result.IsValid = false;
                result.Errors.Add("Reporter name must be at least 2 characters long.");
            }

            // Validate Reporter Contact
            if (string.IsNullOrWhiteSpace(item.ReporterContact))
            {
                result.IsValid = false;
                result.Errors.Add("Contact information is required.");
            }
            else if (!IsValidEmail(item.ReporterContact) && !IsValidPhoneNumber(item.ReporterContact))
            {
                result.IsValid = false;
                result.Errors.Add("Contact must be a valid email or phone number.");
            }

            // Validate Date
            if (item.DateReported > DateTime.Now)
            {
                result.IsValid = false;
                result.Errors.Add("Report date cannot be in the future.");
            }

            // Specific validation for LostItem
            if (item is LostItem lostItem)
            {
                if (lostItem.DateLost > DateTime.Now)
                {
                    result.IsValid = false;
                    result.Errors.Add("Date lost cannot be in the future.");
                }

                if (lostItem.DateLost < DateTime.Now.AddYears(-1))
                {
                    result.IsValid = false;
                    result.Errors.Add("Date lost cannot be more than 1 year ago.");
                }
            }

            // Specific validation for FoundItem
            if (item is FoundItem foundItem)
            {
                if (foundItem.DateFound > DateTime.Now)
                {
                    result.IsValid = false;
                    result.Errors.Add("Date found cannot be in the future.");
                }

                if (foundItem.DateFound < DateTime.Now.AddYears(-1))
                {
                    result.IsValid = false;
                    result.Errors.Add("Date found cannot be more than 1 year ago.");
                }

                if (string.IsNullOrWhiteSpace(foundItem.CurrentLocation))
                {
                    result.IsValid = false;
                    result.Errors.Add("Current location (where item is kept) is required.");
                }
            }

            return result;
        }

        //Validates email format using regex
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Simple email regex pattern
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
        }

        // validates au number format
        // Accepts formats like: 0400123456, 04 0012 3456, (02) 1234 5678
        public bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Remove spaces, dashes, and parentheses
            string cleanPhone = Regex.Replace(phone, @"[\s\-\(\)]", "");

            // Check if it's a valid Australian phone number
            // Mobile: 04XX XXX XXX (10 digits starting with 04)
            // Landline: 0X XXXX XXXX (10 digits starting with 02-08)
            string pattern = @"^0[2-478]\d{8}$";
            return Regex.IsMatch(cleanPhone, pattern);
        }

        //Validates user registration input
        public ValidationResult ValidateUser(User user)
        {
            var result = new ValidationResult { IsValid = true };

            // Validate Name
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                result.IsValid = false;
                result.Errors.Add("Name is required.");
            }
            else if (user.Name.Length < 2)
            {
                result.IsValid = false;
                result.Errors.Add("Name must be at least 2 characters long.");
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                result.IsValid = false;
                result.Errors.Add("Email is required.");
            }
            else if (!IsValidEmail(user.Email))
            {
                result.IsValid = false;
                result.Errors.Add("Email format is invalid.");
            }

            // Validate Phone (optional but if provided must be valid)
            if (!string.IsNullOrWhiteSpace(user.PhoneNumber) && !IsValidPhoneNumber(user.PhoneNumber))
            {
                result.IsValid = false;
                result.Errors.Add("Phone number format is invalid.");
            }

            return result;
        }

        //Validates Search query
        public ValidationResult ValidateSearchQuery(string query)
        {
            var result = new ValidationResult { IsValid = true };

            if (string.IsNullOrWhiteSpace(query))
            {
                result.IsValid = false;
                result.Errors.Add("Search query cannot be empty.");
            }
            else if (query.Length < 2)
            {
                result.IsValid = false;
                result.Errors.Add("Search query must be at least 2 characters long.");
            }
            else if (query.Length > 100)
            {
                result.IsValid = false;
                result.Errors.Add("Search query is too long (max 100 characters).");
            }

            return result;
        }

        //Sanitizes user input to prevent injection attacks
        public string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Remove potentially dangerous characters
            input = input.Trim();

            // Remove HTML tags
            input = Regex.Replace(input, @"<[^>]*>", string.Empty);

            // Remove script tags
            input = Regex.Replace(input, @"<script[^>]*>.*?</script>", string.Empty, RegexOptions.IgnoreCase);

            return input;
        }
    }
    // Represents the result of a validation operation
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }

        public ValidationResult()
        {
            Errors = new List<string>();
        }

        // gets all error messages as a single string
        public string GetErrorMessage()
        {
            return string.Join("\n", Errors);
        }

        //gets error count
        public int ErrorCount()
        {
            return Errors.Count;
        }
    }
}
