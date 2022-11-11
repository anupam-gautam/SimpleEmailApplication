using Microsoft.EntityFrameworkCore;

namespace SimpleEmailApplication.Data
{
    public class EmailVerificationDbContext : DbContext
    {
        public EmailVerificationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmailDto> EmailDtos { get; set; }

    }
}
