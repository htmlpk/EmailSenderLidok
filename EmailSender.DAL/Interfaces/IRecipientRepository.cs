using EmailSender.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.DAL.Interfaces
{
    public interface IRecipientRepository : IGenericRepository<Recipient>
    {
        Task<IEnumerable<Recipient>> GetAllWithGroup();
    }
}
