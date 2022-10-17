using Business_Logic.DTO.BaseDTOs;

namespace Business_Logic.DTO.PostDTOs
{
    public class PostCreateDTO 
    {
        public string Title { get; set; }
        public string TextContent { get; set; }

        public string CategoryId { get; set; }
        //public Guid UserId { get; set; }
    }
}
