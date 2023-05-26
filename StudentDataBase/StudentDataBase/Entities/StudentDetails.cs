using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StudentDataBase.Entities
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Display(Name = "Roll No")]
        public int Roll_No { get; set; }
        [Display(Name = "Family Name")]
        public string Family_Name { get; set; } = null!;
        public string Address { get; set; } = null!;

        [Display(Name = "Contact Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? Contact_No { get; set; }
    }
}
