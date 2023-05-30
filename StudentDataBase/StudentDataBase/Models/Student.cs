using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using MessagePack;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace StudentDataBase.Models
{
    public class Student
    {  
        public  int Id { get; set; }
        [Required]
        public int Roll_No { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Family_Name { get; set; }

        [DisplayName("Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date_of_Birth { get; set; }
        
        
        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is required.")]
        public string? Location { get; set; }

        
        
        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? Contact_No { get; set; }

    }
}
