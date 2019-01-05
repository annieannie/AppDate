using System;
using System.Collections.Generic;
using datingapp.api.Models;
using Newtonsoft.Json;

namespace datingapp.api.Data
{
    public class seed
    {
        private readonly DataContext _context;
        public seed (DataContext context)
        {
            _context = context;
        }

        public void SeedUsers () { 
            var userData = System.IO.File.ReadAllText("Data/UsersSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users) {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
            }

            _context.SaveChanges();
         }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
             using(var hmac = new System.Security.Cryptography.HMACSHA512())
             {
                passwordSalt =hmac.Key;
                passwordHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}