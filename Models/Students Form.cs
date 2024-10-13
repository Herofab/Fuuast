namespace fuuast.Models
{
    public class Students_Form
    {
        public int? Id { get; set; }
        public int? practiceId { get; set; }
        public int? staffId { get; set; }
        public bool? inactive { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fatherName { get; set; }
        public string fatherCNIC { get; set; }
        public string motherName  { get; set; }
        public string motherCNIC { get; set; }
        public string fatherNumber { get; set; }
        public bool? Isguardian { get; set; }
        public string guardianName { get; set;}
        public string gardianCNIC { get; set; }
        public string Dob {  get; set; }
        public string Domicil { get; set; }
        public string district {  get; set; }
        public string province { get; set; }
        public string subDivision { get; set; }
        public int? DepartmentId { get; set; }
        public string emailAddress { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string postelCode { get; set; }
        public string phoneNumber { get; set; }
        public string Gender { get; set; }
        public string CNIC { get; set; }
        public string AddmissionDate { get; set; }
        public string fronturl { get; set; }
        public string backurl { get; set; }
        public string Domicilurl { get; set; }
        public string Matricmarksheeturl { get; set; }
        public string Fscmsheeturl { get; set; }
        public string Bsmsheeturl { get; set; }
        public string MsMsheeturl { get; set; }
        public bool? Isenrolledinschollarship { get; set; }
        public string Msheeturl {  get; set; }
        public string SchollarshipId { get; set; }
        public bool? Isenrolled {  get; set; }
        public int? EnrollemntId { get; set; } 
        public DateTime? createdTime   { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedTime { get; set; }
        public string updatedBy { get; set; }







    }
}
