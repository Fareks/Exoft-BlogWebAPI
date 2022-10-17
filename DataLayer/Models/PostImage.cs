using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class PostImage
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime UploadDate { get; set; }
        public Guid PostId { get; set; }
        [JsonIgnore]
        public Post Post { get; set; }
    }
}
