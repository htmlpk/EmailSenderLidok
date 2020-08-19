using EmailSender.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.DAL.Interfaces
{
    public interface IEmailHandlerRepository : IGenericRepository<Email>, IDisposable
    {
        public Task<IEnumerable<Email>> GetNewWithTemplates();
        public IQueryable<Email> GetAllFailed();
    }
}
