using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace fuuast.Models
{
    public class departments
    {
        public int id { get; set; }
        public string depName { get; set; }
        public string depCode { get; set; }
        public int? practiceId { get; set; }
        public string type { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public bool? inactive { get; set; }

    }
}
