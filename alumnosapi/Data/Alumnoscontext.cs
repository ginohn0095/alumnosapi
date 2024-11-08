using alumnosapi;
using Microsoft.EntityFrameworkCore;
namespace alumnosapi.Models
   
{
    public class Alumnoscontext: DbContext
    {
        public Alumnoscontext(DbContextOptions<Alumnoscontext>options):base(options) { }
        public DbSet<Alumno> Alumnos { get; set; }
        
    }
}
