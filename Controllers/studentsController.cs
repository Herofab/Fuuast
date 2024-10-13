using Microsoft.AspNetCore.Mvc;
using fuuast.Models;
using fuuast.Models.Auths;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DbContext = fuuast.Models.DbContext;
namespace fuuast.Controllers
{
    public class studentsController : Controller
    {
        private readonly Models.DbContext _context;
        private readonly IConfiguration _config;


        public studentsController(DbContext context, IConfiguration config)
        {
            _context = context;
            _config = config; // Ensure IConfiguration is injected here
        }
        //--------------------Add New Student----------------------------//
        [Authorize]
        [HttpPost("Addstudent")]
        public async Task<object> Addstudent([FromBody] StudentsForm studentForm)
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

                    //for delete student
                    if (studentForm.Id > 0 && studentForm.inactive==true)
                    {
                        studentForm.updatedBy = userName;
                        studentForm.updatedTime = DateTime.Now;
                        studentForm.inactive = true;
                        _context.StudentsForm.Update(studentForm);
                        await _context.SaveChangesAsync();
                        return Ok(studentForm); // Return the updated user
                    }
                    // Proceed with adding the user
                    if (studentForm.Id == 0)
                    {
                        studentForm.Id = 0;
                        studentForm.practiceId = practiceId;
                        studentForm.createdBy = userName;
                        studentForm.createdTime = DateTime.Now;
                        studentForm.inactive = false;
                        _context.StudentsForm.Add(studentForm);
                        await _context.SaveChangesAsync(); // Use async save

                        // Return created user object
                        return Ok(studentForm); // Return the created user
                    }
                    //updating student
                    if (studentForm.Id > 0)
                    {
                        studentForm.updatedBy = userName;
                        studentForm.updatedTime = DateTime.Now;
                        studentForm.inactive = false;
                        _context.StudentsForm.Update(studentForm);
                        await _context.SaveChangesAsync();
                        return Ok(studentForm); // Return the updated user
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
