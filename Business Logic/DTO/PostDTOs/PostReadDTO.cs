using Business_Logic.DTO.CommentDTOs;
using Business_Logic.DTO.PostLikeDTOs;

namespace Business_Logic.DTO.PostDTOs
{
    public class PostReadDTO
    {
        public string Title { get; set; }
        public string TextContent { get; set; }
        public int LikeSnapshot { get; set; }
        public bool VerifyStatus { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CommentDTO>? Comments { get; set; }
        public ICollection<PostLikeDTO>? PostLikes { get; set; }
    }
}
