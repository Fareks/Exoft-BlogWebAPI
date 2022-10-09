using Business_Logic.DTO.CommentDTOs;
using Business_Logic.DTO.PostLikeDTOs;
using DataLayer.Models;
using System.Text.Json.Serialization;

namespace Business_Logic.DTO.PostDTOs
{
    public class PostReadDTO
    {
        public Guid Id { get; set; }    
        public string Title { get; set; }
        public string TextContent { get; set; }
        public int LikeSnapshot { get; set; }
        public bool VerifyStatus { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CommentDTO>? Comments { get; set; }
        public ICollection<PostLikeDTO>? PostLikes { get; set; }
        public Guid PostImageId { get; set; }
        [JsonIgnore]
        public PostImage? PostImage { get; set; }
    }
}
