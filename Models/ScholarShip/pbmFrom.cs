namespace fuuast.Models.ScholarShip
{
    public class pbmFrom
    {
        public int id { get; set; }
        public int practiceId { get; set; }
        public int staffId { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string stdCNIC { get; set; }
        public string fatherCNIC { get; set; }
        public string motherCNIC { get; set; }
        public string permanentAddress { get; set; }
        public bool? inactive { get; set; }
        public string contactNumber { get; set; }
        public string financialAssistance { get; set; }
        public bool? IsfinancialAssistance { get; set; }
        public string Residence { get; set; }
        public bool? IsResidencerent { get; set; }
        public string rent { get; set; }
        public bool? Isownproperty { get; set; }
        public string propertyOwnername { get; set; }
        public string popertyWorth { get; set; }
        public string studentApplicationUrl { get; set; }
        public bool? IsAttestedCNIC { get; set; }
        public bool? IsAttestedfatherCNIC { get; set; }
        public bool? IsAttestedmotherCNIC { get; set; }
        public bool? IsAttestedcertificate { get; set; }
        public bool? IsAffidavitProforma { get; set; }
        public DateTime? createdDate { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public string updatedBy { get; set; }
        public bool? isAuthverified { get; set; }











    }
}
