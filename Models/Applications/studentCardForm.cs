namespace fuuast.Models.Applications
{
    public class studentCardForm
    {
     public int Id { get; set; }
     public int? practiceId { get; set; }
     public int? staffId { get; set; }
     public string studentName { get; set; }
     public string fatherName  { get; set; }
     public string department {  get; set; }
     public string program { get; set; }
     public string session { get; set; }
     public string semester { get; set; }
     public string CNIC { get; set; }
     public string MISID { get; set; }
     public string postelAddress  { get; set; }
     public string contactNo { get; set; }
     public DateTime? createdDate { get; set; }
     public string createdBy  { get; set; }
     public DateTime? updatedDate { get; set; }
     public string updatedBy { get; set; }
     public bool? inactive { get; set; } 
     



    }
}
