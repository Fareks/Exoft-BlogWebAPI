using Business_Logic.Services;
using Business_Logic.Services.CommentLikeServices;
using Business_Logic.Services.CommentServices;
using Business_Logic.Services.ImageServices;
using Business_Logic.Services.PostLikesServices;
using Business_Logic.Services.PostServices;
using Business_Logic.Services.UserServices;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;

namespace Exoft_BlogWebAPI
{
    public static class ServicesManager
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserServices>();
            services.AddTransient<IPostService, PostServices>();
            services.AddTransient<ICommentService, CommentServices>();
            services.AddTransient<IPostLikeService, PostLikeServices>();
            services.AddTransient<ICommentLikeService, CommentLikeServices>();
            
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddTransient<IUserImageService, UserImageService>();
            services.AddTransient<IPostImageService, PostImageService>();

        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IRepository<PostLike>, PostLikeRepository>();
            services.AddTransient<IRepository<Comment>, CommentRepository>();
            services.AddTransient<IRepository<CommentLike>, CommentLikeRepository>();
            services.AddTransient<IImageRepository<UserImage>, UserImageRepository>();
            services.AddTransient<IImageRepository<PostImage>, PostImageRepository>();
        }


    }
}
