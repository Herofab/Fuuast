using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DbContext = fuuast.Models.DbContext;
using fuuast.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using fuuast.Models.Auths;
using System.Security.Cryptography;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace fuuast.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly IConfiguration _config;

        public TokenController(DbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            // Fetch the user from the database based on the username
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.userName == userLoginDto.Username);

            if (existingUser == null)
            {
                return Unauthorized("Invalid username."); // Username does not exist
            }

            // Decrypt the stored password and compare it with the provided password
            string decryptedPassword = Decryptpass(existingUser.password);

            if (decryptedPassword != userLoginDto.Password)
            {
                return Unauthorized("Invalid password."); // Password does not match
            }

            // Generate JWT token for the authenticated user
            var token = GenerateToken(existingUser);

            // Set the token in the user object
            existingUser.Token = token;

            return Ok(existingUser); // Return user object along with token
        }

        // Method to decrypt the stored password
        private string Decryptpass(string encryptedPassword)
        {
            string encryptionKey = _config["Encryption:Key"]; // Fetch the key from appsettings.json
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(encryptedPassword);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        // Method to generate a JWT token
        private string GenerateToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            // Create token descriptor and add claims
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, user.userName),
            new Claim(ClaimTypes.Email, user.email),
            new Claim("IsAdmin", user.isAdmin.ToString()),
            new Claim("Id", user.Id.ToString()),
            new Claim("practiceId", user.Id.ToString()), // Add practiceId claim
            new Claim("username", user.userName) // Add username claim
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    // DTO for login request
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
