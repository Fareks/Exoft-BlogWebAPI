using Business_Logic.DTO.BaseDTOs;

namespace Business_Logic.DTO.PostLikeDTOs
{
    public class PostLikeCreateDTO
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
