using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class DemoDbContext: IdentityDbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
