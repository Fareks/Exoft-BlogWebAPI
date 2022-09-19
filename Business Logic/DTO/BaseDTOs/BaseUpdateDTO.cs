namespace Business_Logic.DTO.BaseDTOs
{
    public class BaseUpdateDTO
    {
        public Guid Id { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }
}
