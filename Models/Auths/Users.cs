using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace fuuast.Models.Auths
{
    public class Users
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string Address { get; set; }
        public bool? inactive { get; set; }
        public bool? isActive { get; set; }
        public string phoneNumber { get; set; }
        public bool? isAdmin { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? updatedDate { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }

        [NotMapped] // This property will not be mapped to the database
        public string Token { get; set; }
    }
}
