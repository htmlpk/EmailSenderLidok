using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Enums;
using EmailSender.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.DAL.Repository
{
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        ApplicationContext _context;
        public EmailRepository(ApplicationContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Email>> GetNewWithTemplates()
        {
            return await _context.Emails.Include(e=>e.Template).Include(e => e.Recipient).Where(em=>em.Status == Enums.EmailStatus.New).AsNoTracking().ToListAsync();
        }
        public IQueryable<Email> GetAllFailed()
        {
            return _context.Emails.Where(e => e.Status != EmailStatus.Finished);
        }
    }
}
