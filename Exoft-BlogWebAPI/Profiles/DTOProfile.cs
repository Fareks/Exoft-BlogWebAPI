using AutoMapper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic.DTO.BaseDTOs;
using Business_Logic.DTO.CommentDTOs;
using Business_Logic.DTO.CommentLikeDTOs;
using Business_Logic.DTO.PostDTOs;
using Business_Logic.DTO.PostLikeDTOs;
using Business_Logic.DTO.UserDTOs;
using Business_Logic.DTO.CategoryDTOs;

namespace DataLayer.Profiles
{
    internal class DTOProfile : Profile
    {
        public DTOProfile()
        {
            CreateMap<BaseEntity, BaseDTO>().ReverseMap();
            CreateMap<BaseEntity, BaseUpdateDTO>().ReverseMap();
            CreateMap<BaseEntity, BaseCreateDTO>().ReverseMap();


            CreateMap<User, UserReadDTO>().ReverseMap();
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
            CreateMap<PostLike, PostLikeWithPostDTO>().ReverseMap();

            CreateMap<CommentLike,CommentLikeDTO>().ReverseMap();
            CreateMap<CommentLike, CommentLikeCreateDTO>().ReverseMap();
            CreateMap<CommentLike, CommentLikeReadDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            

        }
    }
}
