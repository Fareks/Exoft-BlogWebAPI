using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        public Task<List<Post>> GetAllByUserId(Guid userId, CancellationToken token = default);
        public Task<int> UpdateLikeSnapshot(Guid id,CancellationToken token = default);
        public Task<List<Post>> GetAllUnverifiedPosts(CancellationToken token = default);
        public Task<List<Post>> GetPostsByCategoryId(Guid categoryId,CancellationToken token = default);
        public Task<List<Post>> GetLastPosts(int skip, int take,CancellationToken token = default);
        public Task DeleteById(Guid id,CancellationToken token = default);
        //public Task<IEnumerable<Post>> GetAllLikedPostsByUserId(Guid userId);
        public Task<IEnumerable<Post>> SearchByContent(string content,CancellationToken token = default);

    }
}
