using Microsoft.EntityFrameworkCore;
using crud.Models.Entities;

namespace crud.Models.Entities
{
    public class StudentsContext : DbContext

    {



        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {

        }


        public DbSet<Students> Students { get; set; }
        public DbSet<Classrooms> Classrooms { get; set; }
        public DbSet<Grades> Grade { get; set; }
        public DbSet<Subjects> Subject { get; set; }
        public DbSet<Teachers> Teacher { get; set; }
        public DbSet<TeacherSchedule> TeacherSchedule { get; set; }



    }
}

