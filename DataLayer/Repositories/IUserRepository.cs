﻿
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByEmailAsync(string email);
    }
}