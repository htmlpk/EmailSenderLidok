using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Interfaces;

namespace EmailSender.DAL.Repository
{
    public class TemplateRepository : GenericRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(ApplicationContext dbContext)
            : base(dbContext)
        {
        }
    }
}
