using FinTechGroup.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinTechGroup.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

    }
        public DbSet<Company> Companies { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}