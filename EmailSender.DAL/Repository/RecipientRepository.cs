using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EmailSender.DAL.Repository
{
    public class RecipientRepository : GenericRepository<Recipient>,IRecipientRepository
    {
        private ApplicationContext _dbContext;
        public RecipientRepository(ApplicationContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Recipient>> GetAllWithGroup()
        {
            //var recipients = await _dbContext.Recipients.Include(r => r.RecipientInGroups.Select(rig => rig.Group)).ToListAsync();
            var recipients = await _dbContext.Recipients.Include(r => r.RecipientInGroups).ThenInclude(it => it.Group).ToListAsync();
            return recipients;
        }
    }
}
