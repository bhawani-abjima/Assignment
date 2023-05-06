﻿namespace ASPWebAPI.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RollNo { get; set; }
        public string FamilyName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Contact { get; set; }
    }
}
