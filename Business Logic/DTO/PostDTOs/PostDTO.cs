using Business_Logic.DTO.BaseDTOs;
using Business_Logic.DTO.CommentDTOs;
using Business_Logic.DTO.PostLikeDTOs;
using Business_Logic.DTO.UserDTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business_Logic.DTO.PostDTOs
{
    public class PostDTO : BaseDTO
    {
        public string Title { get; set; }
        public string TextContent { get; set; }
        public int LikeSnapshot { get; set; }
        public bool VerifyStatus { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CommentDTO>? Comments { get; set; }
        public ICollection<PostLikeDTO>? PostLikes { get; set; }
        public Guid? PostImageId { get; set; }
        [JsonIgnore]
        public PostImage? PostImage { get; set; }
        public UserReadDTO? User { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
