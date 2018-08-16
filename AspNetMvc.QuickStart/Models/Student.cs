using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetMvc.QuickStart.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public int Gender { get; set; }
        [Required]
        [StringLength(200)]
        public string Major { get; set; }
        public DateTime EntranceDate { get; set; }
    }

    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}