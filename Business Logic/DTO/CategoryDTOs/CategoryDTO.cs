using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business_Logic.DTO.CategoryDTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid? CategoryImageId { get; set; }
        [JsonIgnore]
        public CategoryImage? CategoryImage { get; set; }
    }
}
