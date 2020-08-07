using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Interfaces;

namespace EmailSender.DAL.Repository
{
    public class GroupRepository : GenericRepository<Group>,IGroupRepository
    {
        public GroupRepository(ApplicationContext dbContext)
            : base(dbContext)
        {
        }
    }
}
