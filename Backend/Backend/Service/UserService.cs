using Backend.Models;
using Backend.Models.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Backend.Service
{
    public class UserService
    {
        private readonly MaindbContext _context;

        public UserService(MaindbContext context)
        {
            _context = context;
        }

        public User? ValidateUser(string email, string password)
        {
            var userData = (from x in _context.EpUsers
                           where x.UserEmail == email
                           select new User{
                           UserEmail= x.UserEmail,
                           UserFullName= x.UserFullName,
                           Userid= x.Userid,
                           UserPhone  = x.UserPhone,
                           UserPreferName = x.UserPreferName,
                           PasswordHash = x.PasswordHash,
                           }).FirstOrDefault();
            if (userData == null) {
                return null;
            }
            if (hashPassword(password) ==userData.PasswordHash) {
                return userData;
            }

            return null;
        }

        public string hashPassword(string password) {
            //byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
        

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                 //salt: salt,
                salt: new byte[0],
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
