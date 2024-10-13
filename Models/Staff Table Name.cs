namespace fuuast.Models
{
    public class Staff_Table_Name
    { 
        public int? Id { get; set; }
        public int? practiceId { get; set; }
        public int? staffId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Emailaddress { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string Postalcode { get; set; }
        public string phoneNumber { get; set; }
        public string Gender { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? inactive { get; set; }
        public string CNIC { get; set; }
        public string Designation { get; set; }
        public string HiringDate { get; set; }
        public string Type { get; set; }
        public DateTime? createdDate { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedDate { get; set; } 
        public string updatedBy { get; set; }



    }
}
