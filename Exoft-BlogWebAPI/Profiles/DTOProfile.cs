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
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<PostLike,PostLikeDTO>().ReverseMap();
            CreateMap<CommentLike,CommentLikeDTO>().ReverseMap();
        }
    }
}
