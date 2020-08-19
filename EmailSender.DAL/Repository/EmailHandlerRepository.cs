using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Enums;
using EmailSender.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.DAL.Repository
{
    public class EmailHandlerRepository : GenericRepository<Email>, IEmailHandlerRepository
    {
        HostedContext _hostedContext;
        public EmailHandlerRepository(HostedContext hostedContext)
            : base(hostedContext)
        {
            _hostedContext = hostedContext;
        }

        public async Task<IEnumerable<Email>> GetNewWithTemplates()
        {
           return await _hostedContext.Emails
                .Include(e => e.Template)
                .Include(e => e.Recipient)
                .Where(em => em.Status == Enums.EmailStatus.New)
                //.AsNoTracking()
                .ToListAsync();
        }
        public IQueryable<Email> GetAllFailed()
        {
            return _hostedContext.Emails.Where(e => e.Status != EmailStatus.Finished);
        }


        #region IDisposable Support

        public void Dispose()
        {
            this._hostedContext.Dispose();
        }
        #endregion
    }
}
