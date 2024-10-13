namespace fuuast.Models
{
    public class candidateform
    {
        public int Id { get; set; }
        public int? practiceId { get; set; }
        public int? staffId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fatherName { get; set; }
        public string fatherCNIC { get; set; }
        public string motherName { get; set; }
        public string motherCNIC { get; set; }
        public string fatherPhone { get; set; }
        public bool? Isgardian { get; set; }
        public string gardianName { get; set; }
        public string gardianCNIC { get; set; }
        public string dob {  get; set; }
        public string domicil {  get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public string subDivision { get; set; }
        public int? departmentId { get; set; }
        public string Subdepartment {  get; set; }
        public string subDepartment2 { get; set; }
        public string subDepartment3 { get; set; }
        public string EmailAddress { get; set; }
        public string city { get; set; }
        public string state {  get; set; }
        public string postelCode { get; set; }
        public string phoneNumber  { get; set; }
        public string gender { get; set; }
        public string CNIC { get; set; }
        public string testDate { get; set; }
        public string CNICfronturl { get; set; }
        public string CNICbackurl { get; set; }
        public string domicilurl { get; set; }
        public string matricMarksurl  { get; set; }
        public string fscmarksheeturl { get; set; }
        public string bsmarksheeturl { get; set; }
        public string msmarksheeturl { get; set; }
        public bool? inactive  { get; set; }
        public DateTime? DateTime { get; set; }
        public string createdTime { get; set; }
        public DateTime? updatedTime { get; set; }
        public string updatedBy { get; set; }



    }
}
