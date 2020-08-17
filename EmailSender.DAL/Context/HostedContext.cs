

using EmailSender.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.DAL.Context
{
    public class HostedContext : DbContext
    {
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Template> Templates { get; set; }

        public HostedContext(DbContextOptions<HostedContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
