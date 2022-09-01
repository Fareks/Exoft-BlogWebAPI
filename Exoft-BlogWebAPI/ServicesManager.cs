using Business_Logic.Services;
using Business_Logic.Services.PostServices;
using Business_Logic.Services.UserServices;
using DataLayer.Models;
using DataLayer.Repositories;
namespace Exoft_BlogWebAPI
{
    public static class ServicesManager
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IService<User>, UserServices>();
            services.AddTransient<IService<Post>, PostServices>();
            //services.AddTransient<IService<Comment>,CommentServices>();
            //services.AddTransient<IService<PostLike>, PostLikeServices>();
            //services.AddTransient<IService<CommentLike>, CommentLikeServices>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Post>, PostRepository>();
            services.AddTransient<IRepository<PostLike>, PostLikeRepository>();
            services.AddTransient<IRepository<Comment>, CommentRepository>();
            services.AddTransient<IRepository<CommentLike>, CommentLikeRepository>();
        }


    }
}
