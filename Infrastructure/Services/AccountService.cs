using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUser(RegisterModel model)
        {
            // need to go to user table and get the user record by email
            // check if the email user entered does not exists in the database

            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                // 
                throw new Exception("Duplicate Email, please login");
            }
            // if email does not exists then hash the password with salt and save the salt and hashed password in the database
            // never ever create your own hashing algoritm
            // always use inditsry tried and tested algoritmns

            var salt = GetRandomSalt();
            var hashedPassword = GetHashedPassword(model.Password, salt);

            // save the salt and email, fname, lastname User Table

            // create user entity
            var newUser = new User { 
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Salt = salt,
                DateOfBirth = model.DateOfBirth,
                HashedPassword = hashedPassword
            };

            await _userRepository.Add(newUser);
            // return newly created Usr Id
            return true;
        }

        public async Task<UserInfoModel> ValidateUser(string email, string password)
        {
            // get the user record by email
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("Email does not exists");
            }

            // check if user exists in the database, only if user exisst then compare the hashes 
            var hashedPasswrod = GetHashedPassword(password, user.Salt);
            if (hashedPasswrod == user.HashedPassword)
            {
                //good passwords match
                var userInfo = new UserInfoModel
                {
                    Email = user.Email, Id = user.Id,FirstName = user.FirstName, LastName = user.LastName, DateOfBirth = user.DateOfBirth.GetValueOrDefault()
                };
                return userInfo;
            }

            throw new Exception("email/password does not match");
           
        }

        private string GetRandomSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
           password,
           Convert.FromBase64String(salt),
           KeyDerivationPrf.HMACSHA512,
           10000,
           256 / 8));
            return hashed;
        }
    }
}
