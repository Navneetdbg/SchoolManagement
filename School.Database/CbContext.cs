using School.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database
{
   public class CbContext:DbContext
    {
        public CbContext():base("SMSystem")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
           
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Homework> HomeWorks { get; set; }
        public DbSet<Parent> Parents { get; set; }

        

        public DbSet<Report> Reports { get; set; }

        public DbSet<SchoolClass> SchoolClasses { get; set; }

        

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }



    }
}
