using Microsoft.AspNetCore.Mvc;
using fuuast.Models;
using fuuast.Models.Auths;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using DbContext = fuuast.Models.DbContext;
namespace fuuast.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly Models.DbContext _context;
        private readonly IConfiguration _config;


        public DepartmentController(DbContext context, IConfiguration config)
        {
            _context = context;
            _config = config; // Ensure IConfiguration is injected here
        }
        [Authorize]
        [HttpPost("AddDepartment")]
        public async Task<object> AddDepartment([FromBody] departments depart)
        {
            // Check if the user identity claim exists
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null && identity.IsAuthenticated)
            {
                // Get the user claim (you can replace "practiceId" with any claim key you want)
                var userClaim = identity.FindFirst("practiceId")?.Value;
                int practiceId = Convert.ToInt32(userClaim);
                var userName = identity.FindFirst("username")?.Value;

                if (userClaim != null)
                {
                    // Proceed with adding the user
                    if (depart.id == 0)
                    {
                        depart.createdBy = userName;
                        depart.createdDate = DateTime.Now;
                        depart.inactive = false;
                        _context.department.Add(depart);
                        await _context.SaveChangesAsync(); 
                        return Ok(depart); // Return the created user
                    }
                    if (depart.id > 0)
                    {
                        depart.updatedBy = userName;
                        depart.updatedDate = DateTime.Now;
                        _context.department.Update(depart);
                        await _context.SaveChangesAsync();
                        return Ok(depart); // Return the updated user
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

    }
}
