﻿using EmailSender.DAL.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.DAL.Interfaces
{
    public interface IEmailRepository : IGenericRepository<Email>
    {
        public Task Create(Email entity);
    }
}
