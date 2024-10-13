namespace fuuast.Models
{
    public class librarycard
    {
        public int Id { get; set; }
        public int? practiceId { get; set; }
        public int? staffId { get; set; }
        public string name { get; set; }
        public string fatherName { get; set; }
        public string Class {  get; set; }
        public string registrationNumber {  get; set; }
        public string semester { get; set; }
        public string department { get; set; }
        public string shift { get; set; }
        public string CNIC { get; set; }
        public string permanentAddress { get; set; }
        public string PTCLphoneNUMBER { get; set; }
        public string mobileNumber { get; set; }
        public string libraryFee { get; set; }
        public string bankreciptNumber { get; set; }
        public string depositeFeeDate { get; set; }
        public bool? inactive { get; set; }
        public DateTime? DateTime { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedTime { get; set; }
        public string updatedBy { get; set; }




    }
}
