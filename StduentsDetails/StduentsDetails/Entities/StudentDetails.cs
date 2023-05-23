using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions; 

namespace StudentsDetails.Entities

{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RollNo { get; set; }
        public string FamilyName { get; set; } = null!;
        public string Address { get; set; } = null!;

        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? Contact { get; set; }
    }
}
