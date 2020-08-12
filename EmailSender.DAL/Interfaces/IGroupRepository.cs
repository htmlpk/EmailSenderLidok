using EmailSender.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.DAL.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        public Task<IEnumerable<Group>> GetWithRecipients();
    }
}
