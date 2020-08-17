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
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        ApplicationContext _context;
        HostedContext _hostedContext;
        public EmailRepository(ApplicationContext dbContext, HostedContext hostedContext)
            : base(dbContext)
        {
            _context = dbContext;
            _hostedContext = hostedContext;
        }

        public new async Task Create(Email entity)
        {
                await _context.Emails.AddAsync(entity);
                await _context.SaveChangesAsync();
        }

        //public async Task<IEnumerable<Email>> GetNewWithTemplates()
        //{
        //   return await _hostedContext.Emails.Include(e => e.Template).Include(e => e.Recipient).Where(em => em.Status == Enums.EmailStatus.New).AsNoTracking().ToListAsync();
        //}
        //public IQueryable<Email> GetAllFailed()
        //{
        //    return _hostedContext.Emails.Where(e => e.Status != EmailStatus.Finished);
        //}

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposedValue)
        //    {
        //        if (disposing)
        //        {
        //            _context.Dispose();
        //        }

        //        disposedValue = true;
        //    }
        //}

       
        //public void Dispose()
        //{
        //    Dispose(true);
        //}
        #endregion
    }
}
