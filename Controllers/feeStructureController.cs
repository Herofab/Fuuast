using fuuast.Models;
using fuuast.Models.Auths;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DbContext = fuuast.Models.DbContext;

namespace fuuast.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class feeStructureController : Controller
    {
        private readonly Models.DbContext _context;
        private readonly IConfiguration _config;
        
       
        public feeStructureController(DbContext context, IConfiguration config)
        {
            _context = context;
            _config = config; // Ensure IConfiguration is injected here
        }
        [Authorize]
        [HttpPost("Addfeestructure")]
        public async Task<object> Addfeestructure([FromBody] feestructure feestruct)
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
                    if (feestruct.Id == 0)
                    {
                        feestruct.createdBy = userName;
                        feestruct.createdDate = DateTime.Now;
                        feestruct.inactive = false;
                        _context.feestructure.Add(feestruct);
                        await _context.SaveChangesAsync(); // Use async save

                        // Return created user object
                        return Ok(feestruct); // Return the created user
                    }
                    if (feestruct.Id > 0)
                    {
                        feestruct.updatedBy = userName;
                        feestruct.updatedDate = DateTime.Now;
                        feestruct.inactive = false;
                        _context.feestructure.Update(feestruct);
                        await _context.SaveChangesAsync();
                        return Ok(feestruct); // Return the updated user
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

        //-------------Getting the fee structure for list--------------------//
        [Authorize]
        [HttpPost("Getfeestructure")]
        public async Task<object> Getfeestructure()
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
                    //--------------------------Getting Data from feeStructure---------------------//
                    var data = from fee in _context.feestructure
                               where fee.practiceId == practiceId // Replace with the actual practiceId
                               && fee.inactive!=true
                               select new
                               {
                                   fee.Id,
                                   fee.practiceId,
                                   fee.staffId,
                                   fee.department,
                                   fee.programme,
                                   fee.TimePeriod,
                                   fee.firstSemFee,
                                   fee.otherSemFee,
                                   fee.inactive,
                                   fee.createdDate,
                                   fee.createdBy,
                                   fee.updatedDate,
                                   fee.updatedBy
                               };

                    // ToList to execute the query and fetch the data
                    var result = data.ToList();
                     return result;
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
        //-------------------------------This Api Ended------------------------------//
    }
}
