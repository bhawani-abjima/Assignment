﻿using System.ComponentModel.DataAnnotations;
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
        
        public int Roll_No { get; set; }
        public string Name { get; set; }
        public string Family_Name { get; set; }

        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? Contact_No { get; set; }
    }
}
