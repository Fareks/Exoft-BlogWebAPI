﻿using Business_Logic.DTO.UserDTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.UserServices
{
    public interface ITokenService
    {
        //public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        //public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public Task<string> CreateToken(UserReadDTO userDTO);
        public Task SetRefreshToken(RefreshToken newRefreshToken, UserReadDTO userDTO);
        public RefreshToken GenerateRefreshToken();
    }
}
