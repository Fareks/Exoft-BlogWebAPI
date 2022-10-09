﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IPostLikeRepository : IRepository<PostLike>
    {
        public Task<List<PostLike>> GetByPostIdAsync(Guid postId);
    }
}
