using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }

    public class BaseUpdateDTO
    {
        public Guid Id { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }
    public class BaseCreateDTO
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
