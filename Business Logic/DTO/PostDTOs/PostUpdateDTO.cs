using Business_Logic.DTO.BaseDTOs;

namespace Business_Logic.DTO.PostDTOs
{
    public class PostUpdateDTO : BaseUpdateDTO
    {
        public string Title { get; set; }
        public string TextContent { get; set; }
        public int LikeSnapshot { get; set; }
        public bool VerifyStatus { get; set; }
        public Guid UserId { get; set; }
    }
}
