using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Interfaces;

namespace EmailSender.DAL.Repository
{
    public class RecipientInGroupRepository : GenericRepository<RecipientInGroup>, IRecipientInGroupRepository { 
        public RecipientInGroupRepository(ApplicationContext dbContext)
            : base(dbContext)
        {
        }
    }
}
