﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO
{
    public class PostLikeDTO : BaseDTO
    {
        public Guid PostId { get; set; }
        public PostDTO Post { get; set; }
        public Guid UserId { get; set; }
        public UserDTO User { get; set; }
    }
}