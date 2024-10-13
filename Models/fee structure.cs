namespace fuuast.Models
{
    public class  feestructure    
    {
        public int Id { get; set; }
        public int practiceId {  get; set; }
        public int staffId { get; set; }
        public string department {  get; set; }
        public string programme { get; set; }
        public string TimePeriod { get; set; }
        public string firstSemFee {  get; set; }
        public string otherSemFee  { get; set; }
        public bool? inactive { get; set; }
        public DateTime? createdDate { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public string updatedBy { get; set; }



    }
}
