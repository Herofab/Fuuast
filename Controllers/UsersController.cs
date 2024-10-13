    using Microsoft.AspNetCore.Mvc;
    using fuuast.Models;
    using fuuast.Models.Auths;
    //using System.Threading.Tasks;
    using System.Data.Entity;
    using Microsoft.AspNetCore.Authorization;
    using System;
    using DbContext = fuuast.Models.DbContext;
    using System.Security.Cryptography.Xml;
    using System.Security.Cryptography;
    using System.Text;
using System.Security.Claims;
namespace fuuast.Controllers
    {
    [Authorize] // Require authorization for the entire controller
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
        {
            private readonly Models.DbContext _context;
            private readonly IConfiguration _config;

        public UsersController(DbContext context, IConfiguration config)
        {
            _context = context;
            _config = config; // Ensure IConfiguration is injected here
        }
        
            //[Authorize]
            [HttpPost("addUser")]
        [HttpPost]
        [Authorize] // Ensure this method is protected by JWT authentication
        public async Task<IActionResult> AddUser([FromBody] Users users)
        {
            // Check if the user identity claim exists
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null && identity.IsAuthenticated)
            {
                // Get the user claim (you can replace "practiceId" with any claim key you want)
                var userClaim = identity.FindFirst("practiceId")?.Value;

                if (userClaim != null)
                {
                    // Proceed with adding the user
                    if (users.Id == 0)
                    {
                        users.createdDate = DateTime.Now;
                        users.inactive = false;
                        users.password = Encryptpass(users.password); // Encrypt the password

                        _context.Users.Add(users);
                        await _context.SaveChangesAsync(); // Use async save

                        // Return created user object
                        return Ok(users); // Return the created user
                    }

                    return BadRequest("Invalid user data."); // Return a bad request if the user ID is not 0
                }
                else
                {
                    return Unauthorized("Invalid user claim."); // Return unauthorized if the claim is not present
                }
            }
            else
            {
                return Unauthorized("User is not authenticated."); // Return unauthorized if the user is not authenticated
            }
        }


        private string Encryptpass(string password)
            {
                string encryptionKey = _config["Encryption:Key"]; // Fetch the key from appsettings.json
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(password);
                            }
                            array = memoryStream.ToArray();
                        }
                    }
                }
                return Convert.ToBase64String(array);
            }

        }
    }
