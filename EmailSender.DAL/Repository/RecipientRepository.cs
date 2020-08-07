using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Interfaces;

namespace EmailSender.DAL.Repository
{
    public class RecipientRepository : GenericRepository<Recipient>,IRecipientRepository
    {
        public RecipientRepository(ApplicationContext dbContext)
            : base(dbContext)
        {
        }
    }
}
