using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext //SchoolContext is our DB.
    {
        public SchoolContext()
        {
            // Uncomment to turn off Lazy Loding
            //this.Configuration.LazyLoadingEnabled = false;
        }

        // Each DbSet corresponds to a Table within the DB.
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Person> People { get; set; } // Table-per-hierarchy (TPH) Inheritance
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; } // Ex: This is Table "Student," each row consists of "Student" data, derived from the Student Class.
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Removes pluralizing convention of Table names.

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID") // If this wasn't explicitly stated, the column name would be InstructorInstructorID. This is why it's best to just name keys "ID".
                    .ToTable("CourseInstructor"));
            modelBuilder.Entity<Department>().MapToStoredProcedures(); // Instructs EF to use stored procedures for Insert, Update, and Delete ops on the Department entity.

        }
    }
}