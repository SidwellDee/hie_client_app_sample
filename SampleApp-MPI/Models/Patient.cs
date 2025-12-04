using Hl7.Fhir.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApp_MPI.Models
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        [StringLength(13, ErrorMessage = "PIN cannot exceed 13 digits"), MinLength(9, ErrorMessage = "PIN can have a minimum of 9 digits")]
        public string PIN { get; set; }

        public string AlternateId { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DOB { get; set; }
        public Sex Sex { get; set; }
        public string? Chiefdom { get; set; }

        public string? Inkhundla { get; set; }
        
        public string? Nationality { get; set; } 
    }

    public enum Sex : byte
    {
        male = 1,
        female = 2,
        other = 3
    }
}
