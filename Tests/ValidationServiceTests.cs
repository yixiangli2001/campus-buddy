using NUnit.Framework;
using campus_buddy.Models;
using campus_buddy.Services;

namespace campus_buddy.Tests
{
    [TestFixture]
    public class ValidationServiceTests
    {
        private ValidationService validationService;

        [SetUp]
        public void Setup()
        {
            validationService = new ValidationService();
        }

        [Test]
        public void ValidateItem_WithValidData_ReturnsValid()
        {
            var item = new LostItem
            {
                Title = "Black Laptop",
                Description = "MacBook Pro 13 inch with case",
                Location = "Library Level 3",
                ReporterName = "John Smith",
                ReporterContact = "john@student.uts.edu.au"
            };

            var result = validationService.ValidateItem(item);

            Assert.That(result.IsValid, Is.True);
            Assert.That(result.Errors.Count, Is.EqualTo(0));
        }

        [Test]
        public void ValidateItem_WithEmptyTitle_ReturnsFalse()
        {
            var item = new LostItem
            {
                Title = "",
                Description = "Some description here",
                Location = "Library",
                ReporterName = "John",
                ReporterContact = "john@student.uts.edu.au"
            };

            var result = validationService.ValidateItem(item);

            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors, Does.Contain("Title is required."));
        }

        [Test]
        public void IsValidEmail_WithValidEmail_ReturnsTrue()
        {
            bool result1 = validationService.IsValidEmail("john@student.uts.edu.au");
            bool result2 = validationService.IsValidEmail("test.user@example.com");

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
        }

        [Test]
        public void IsValidEmail_WithInvalidEmail_ReturnsFalse()
        {
            bool result1 = validationService.IsValidEmail("notanemail");
            bool result2 = validationService.IsValidEmail("");

            Assert.That(result1, Is.False);
            Assert.That(result2, Is.False);
        }

        [Test]
        public void IsValidPhoneNumber_WithValidAustralianNumber_ReturnsTrue()
        {
            bool result1 = validationService.IsValidPhoneNumber("0412345678");
            bool result2 = validationService.IsValidPhoneNumber("04 1234 5678");

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
        }

        [Test]
        public void IsValidPhoneNumber_WithInvalidNumber_ReturnsFalse()
        {
            bool result1 = validationService.IsValidPhoneNumber("123");
            bool result2 = validationService.IsValidPhoneNumber("");

            Assert.That(result1, Is.False);
            Assert.That(result2, Is.False);
        }

        [Test]
        public void SanitizeInput_RemovesHtmlTags()
        {
            string input = "<script>alert('hack')</script>Hello";

            string sanitized = validationService.SanitizeInput(input);

            Assert.That(sanitized, Does.Not.Contain("<script>"));
            Assert.That(sanitized, Does.Contain("Hello"));
        }
    }
}