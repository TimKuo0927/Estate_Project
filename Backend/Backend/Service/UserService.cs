using Backend.Models;
using Backend.Models.Entity;
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

        public string? ValidateUser(string email, string password)
        {
            var userData = (from x in _context.EpUsers
                            where x.UserEmail == email
                            select new
                            {
                                x.Userid,
                                x.UserEmail,
                                x.PasswordHash,
                                x.PasswordSalt
                            }).FirstOrDefault();

            if (userData == null) return null;

            var (hash, _) = HashPassword(password, userData.PasswordSalt);

            if (hash == userData.PasswordHash)
            {
                return userData.UserEmail;
            }

            return null;
        }

        public User? GetUserByEmail(string email)
        {
            var user = _context.EpUsers.FirstOrDefault(u => u.UserEmail == email);
            if (user == null) return null;
            return new User
            {
                //dont return password hash or salt
                Userid = user.Userid,
                UserFullName = user.UserFullName,
                UserPreferName = user.UserPreferName,
                UserEmail = user.UserEmail,
                UserPhone = user.UserPhone
            };
        }

        public bool AddNewUser(EpUser epUser)
        {
            try
            {
                if (epUser.Userid != 0 && _context.EpUsers.Any(u => u.UserEmail == epUser.UserEmail))
                {
                    Console.WriteLine("User with this email already exists.");
                    return false;
                }

                epUser.IsDelete = false;
                epUser.Timestamp = DateTime.Now;

                var (hash, salt) = HashPassword(epUser.PasswordHash);
                epUser.PasswordHash = hash;
                epUser.PasswordSalt = salt;

                _context.EpUsers.Add(epUser);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }



        public (string Hash, string Salt) HashPassword(string password, string? salt = null)
        {
            byte[] saltBytes;

            if (string.IsNullOrEmpty(salt))
            {
                saltBytes = RandomNumberGenerator.GetBytes(16); // 128-bit salt
            }
            else
            {
                saltBytes = Convert.FromBase64String(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 32 // 256 bits
            ));

            return (hashed, Convert.ToBase64String(saltBytes));
        }

    }
}
