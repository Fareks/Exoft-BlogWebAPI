using AutoMapper;
using DataLayer.Models;
using Business_Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Profiles
{
    internal class DTOProfile : Profile
    {
        public DTOProfile()
        {
            CreateMap<BaseEntity, BaseDTO>().ReverseMap();
            CreateMap<BaseEntity, BaseUpdateDTO>().ReverseMap();
            CreateMap<BaseEntity, BaseCreateDTO>().ReverseMap();


            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<User, UserReadDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();

            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Post, PostUpdateDTO>().ReverseMap();
            CreateMap<Post, PostCreateDTO>().ReverseMap();
            CreateMap<Post, PostReadDTO>().ReverseMap();

            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Comment, CommentReadDTO>().ReverseMap();
            CreateMap<Comment, CommentUpdateDTO>().ReverseMap();
            CreateMap<Comment, CommentCreateDTO>().ReverseMap();

            CreateMap<PostLike,PostLikeDTO>().ReverseMap();
            CreateMap<PostLike, PostLikeReadDTO>().ReverseMap();
            CreateMap<PostLike, PostLikeCreateDTO>().ReverseMap();

            CreateMap<CommentLike,CommentLikeDTO>().ReverseMap();
            CreateMap<CommentLike, CommentLikeCreateDTO>().ReverseMap();
            CreateMap<CommentLike, CommentLikeReadDTO>().ReverseMap();
        }
    }
}
