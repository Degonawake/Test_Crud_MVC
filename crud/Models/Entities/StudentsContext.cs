using Microsoft.EntityFrameworkCore;

namespace crud.Models.Entities
{
    public class StudentsContext : DbContext

    {
    


    public StudentsContext(DbContextOptions<StudentsContext> options)
        : base(options)
    {

    }


    public DbSet<Students> Students { get; set; }

}
}

