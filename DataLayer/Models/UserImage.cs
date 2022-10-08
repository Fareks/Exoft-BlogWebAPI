using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{

    public class UserImage
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime UploadDate { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
