using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.Commons;
using HandMadeCraftAdminServer.DbContext;
using HandMadeCraftAdminServer.Models;
using HandMadeCraftAdminServer.Models.User;
using HandMadeCraftAdminServer.VM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HandMadeCraftAdminServer.Services.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;

        public UserService(AppDbContext db,  IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task UpdateUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        

        public async Task DeleteUser(string id)
        {
            try
            {
                var user =  await _db.Users.FirstOrDefaultAsync(u=>u.Id == id);
                if (user == null) throw new KeyNotFoundException("User not found");
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Email == email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }
        

        // HELPER METHOD
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim("UserId", user.Id),
                    new Claim("Role", user.Role.ToString())
                    // You can add more claims if required
                }),
                Expires = DateTime.Now.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.Now.AddDays(10),
                Created = DateTime.Now,
                CreatedByIp = ipAddress
            };
        }
        
        private static void RemoveOldRefreshTokens(User account)
        {
            account.RefreshTokens.RemoveAll(r => 
                !r.IsActive
                && r.Created.AddDays(AppSettings.RefreshTokenTtl) <= DateTime.Now);
        }
        
        private async Task UpdateRefreshToken(string userId, List<RefreshToken> refreshTokens, string newRefreshToken, string ipAddress)
        {
            // Get the user from the database
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            // Remove old refresh tokens
            RemoveOldRefreshTokens(user);

            // Add the new refresh token
            var refreshToken = new RefreshToken
            {
                Token = newRefreshToken,
                Expires = DateTime.Now.AddDays(10),
                Created = DateTime.Now,
                CreatedByIp = ipAddress 
            };

            user.RefreshTokens.Add(refreshToken);

            // Save changes to the database
            await _db.SaveChangesAsync();
        }

        public async Task<bool> RevokeToken(string token, string ipAddress)
        {
            var user = await _db.Users.Include(user => user.RefreshTokens).FirstOrDefaultAsync(u =>
                u.RefreshTokens.Any(t => t.Token == token) && !u.IsDeleted);
            
            // return false if no user found with token
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.Single(r => r.Token == token);
            
            // return false if token is not active
            if (!refreshToken.IsActive) return false;
            
            // revoke token and save
            refreshToken.Revoked = DateTime.Now;
            refreshToken.RevokedBy = ipAddress;

            await _db.SaveChangesAsync();
            
            return true;
        }
        
        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        
        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }
        

    }
    
    
}