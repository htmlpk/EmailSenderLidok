

using EmailSender.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<RecipientInGroup> RecipientInGroups { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Template> Templates { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
