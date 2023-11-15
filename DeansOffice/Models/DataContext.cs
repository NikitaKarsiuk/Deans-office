using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext") { }

        public virtual DbSet<Faculty> Faculty { get; set;}
        public virtual DbSet<Group> Group { get; set;}
        public virtual DbSet<Student> Student { get; set;}
        public virtual DbSet<StudentGrades> StudentGrades { get; set;}
        public virtual DbSet<Subject> Subject { get; set;}
        public virtual DbSet<SubjectGroupList> SubjectGroupList { get; set;}
    }
}
