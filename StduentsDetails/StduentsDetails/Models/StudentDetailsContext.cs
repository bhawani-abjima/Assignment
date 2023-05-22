﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentsDetails.Controllers;

namespace StudentsDetails.Models
{
    public partial class StudentDetailsContext : DbContext
    {
        private readonly IApplicationBuilder _applicationBuilder;
        private readonly ILogger<HomeController> _logger;

        public StudentDetailsContext()
        {

        }

        public StudentDetailsContext(DbContextOptions<StudentDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentDatum> StudentData { get; set; } = null!;
        public object Students { get; internal set; }
        public object StudentDetails { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDatum>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contact).HasColumnName("contact");

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Family_Name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RollNo).HasColumnName("Roll_No");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
