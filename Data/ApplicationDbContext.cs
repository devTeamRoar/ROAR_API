using Microsoft.EntityFrameworkCore;
using RoarIndustriesApi.Models;

namespace RoarIndustriesApi.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactInquiry> ContactInquiries { get; set; }
    }
}
