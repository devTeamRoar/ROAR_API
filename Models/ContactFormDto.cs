using System.ComponentModel.DataAnnotations;

namespace RoarIndustriesApi.Models
{
    public class ContactFormDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100)]
        public string FullName { get; set; }

        public string? Company { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a Service Interest.")]
        public string ServiceInterest { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 2000 characters.")]
        public string Message { get; set; }
    }
}
