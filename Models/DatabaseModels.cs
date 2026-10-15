using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab4_RazorApi.Models
{
    [Table("teachers")]
    public class Teacher
    {
        [Key, Column("teacherid")] public int TeacherId { get; set; }
        [Column("fullname")] public string FullName { get; set; } = null!;
        public List<Subject> Subjects { get; set; } = new();
    }

    [Table("subjects")]
    public class Subject
    {
        [Key, Column("subjectid")] public int SubjectId { get; set; }
        [Column("name")] public string Name { get; set; } = null!;
        [Column("teacherid")] public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public List<Exam> Exams { get; set; } = new();
    }

    [Table("students")]
    public class Student
    {
        [Key, Column("studentid")] public int StudentId { get; set; }
        [Required, Column("fullname")] public string FullName { get; set; } = null!;
        [Required, Column("address")] public string Address { get; set; } = null!;
        [Required, Column("phone")] public string Phone { get; set; } = null!;
        [Required, Column("birthdate")] public DateTime BirthDate { get; set; }
        [Required, Column("scholarshipamount")] public decimal ScholarshipAmount { get; set; }
        public List<Exam> Exams { get; set; } = new();
    }

    [Table("exams")]
    public class Exam
    {
        [Key, Column("examid")] public int ExamId { get; set; }
        [Column("studentid")] public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        [Column("subjectid")] public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        [Column("examdate")] public DateTime ExamDate { get; set; }
        [Column("grade")] public int Grade { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Exam> Exams { get; set; } = null!;
    }
}