using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoarIndustriesApi.Data;
using RoarIndustriesApi.Models;

namespace RoarIndustriesApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> ContactUs([FromBody] ContactFormDto formData)
        {
            // First, check if an inquiry with the same email already exists.
            // We use ToLower() to make the check case-insensitive.
            var emailExists = await _context.ContactInquiries
                .AnyAsync(inquiry => inquiry.Email.ToLower() == formData.Email.ToLower());

            if (emailExists)
            {
                // If the email is found, return a 409 Conflict error.
                return Conflict(new { message = "A submission with this email address already exists." });
            }

            // If the email is unique, map the incoming data to our database model.
            var contactInquiry = new ContactInquiry
            {
                FullName = formData.FullName,
                Company = formData.Company,
                Email = formData.Email,
                PhoneNumber = formData.PhoneNumber,
                ServiceInterest = formData.ServiceInterest,
                Message = formData.Message
                // The SubmittedAt date is set by default in the ContactInquiry model.
            };

            // Add the new record and save the changes to the database.
            _context.ContactInquiries.Add(contactInquiry);
            await _context.SaveChangesAsync();

            // Return a 200 OK success response.
            return Ok(new { message = "Your message has been received successfully!" });
        }
    }
}
