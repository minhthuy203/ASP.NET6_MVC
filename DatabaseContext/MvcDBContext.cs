using Microsoft.EntityFrameworkCore;
using MVC_Csharp.Models.Contact;

namespace MVC_Csharp.DatabaseContext
{
    public class MvcDBContext : DbContext
    {
        public MvcDBContext(DbContextOptions<MvcDBContext> option) : base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
