using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    internal class PostLikeService : ICRUDService<PostLike>
    {
        AppDbContext dbContext;

        public PostLikeService(AppDbContext _db)
        {
            dbContext = _db;
        }
        public async Task<IEnumerable<PostLike>> GetAll()
        {
            return await dbContext.PostLike.ToListAsync();
        }
        public async Task<PostLike> GetById(Guid id)
        {
            var postLike = await dbContext.PostLike.SingleOrDefaultAsync(x => x.Id == id);
            return (postLike);
        }
        //public void Update(PostLike post)
        //{
        //    dbContext.Update(post);
        //    dbContext.SaveChanges();
        //}
        //public void DeleteById(Guid id)
        //{
        //    if (GetById(id) != null)
        //    {
        //        dbContext.PostLike.Remove(GetById(id));
        //        dbContext.SaveChanges();
        //    }
        //}
        //public void Post(PostLike new_postLike)
        //{
        //    dbContext.PostLike.Add(new_postLike);
        //    dbContext.SaveChanges();
        //}

        Task ICRUDService<PostLike>.Update(PostLike item)
        {
            throw new NotImplementedException();
        }

        Task ICRUDService<PostLike>.DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task ICRUDService<PostLike>.Post(PostLike newItem)
        {
            throw new NotImplementedException();
        }
    }
}
