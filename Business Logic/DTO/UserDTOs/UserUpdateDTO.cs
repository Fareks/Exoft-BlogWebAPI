﻿using Business_Logic.DTO.BaseDTOs;
using Business_Logic.Enums;

namespace Business_Logic.DTO.UserDTOs
{
    public class UserUpdateDTO : BaseUpdateDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}