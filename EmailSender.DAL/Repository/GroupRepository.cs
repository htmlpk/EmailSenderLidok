using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.DAL.Repository
{
    public class GroupRepository : GenericRepository<Group>,IGroupRepository
    {
        ApplicationContext _dbContext;
        public GroupRepository(ApplicationContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Group>> GetWithRecipients()
        {
            var groups = await _dbContext.Groups.Include(r => r.RecipientInGroups).ThenInclude(it => it.Recipient).ToListAsync();
            return groups;
        }

    }
}
