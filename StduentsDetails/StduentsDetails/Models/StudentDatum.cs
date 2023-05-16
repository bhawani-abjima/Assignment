﻿using System;
using System.Collections.Generic;

namespace StudentsDetails.Models
{
    public partial class StudentDatum
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RollNo { get; set; }
        public string FamilyName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public long? Contact { get; set; }
    }
}
