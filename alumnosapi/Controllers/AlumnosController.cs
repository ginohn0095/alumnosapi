using Microsoft.AspNetCore.Mvc;
using alumnosapi.Models;
using alumnosapi.Controllers;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore;


namespace alumnosapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly Alumnoscontext _context;
        public AlumnosController(Alumnoscontext context)
        {
            _context = context;
        }
        //GET:Api/Alumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnos()
        {
            return await _context.Alumnos.ToListAsync();
        }

        //GET:api/Alumnos
        [HttpGet("{Id}")]
        public async Task<ActionResult<Alumno>>GetAlumno(int Id)
        {
            var alumno=await _context.Alumnos.FindAsync(Id);
            if (alumno==null)
            {
                return NotFound();
            }
        return alumno;
        }

        //POST:api/Alumnos
        [HttpPost]
        public async Task<ActionResult> PostAlumno( Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAlumno", new { Id=alumno.Id}, alumno);
        }
        //PUT:api/Alumnos
        [HttpPut("{Id}")]
        public async Task <IActionResult> PutAlumno(int Id, Alumno alumno)
        {
            if (Id != alumno.Id)
            {
                return BadRequest();
            }
            _context.Entry(alumno).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! _context.Alumnos.Any(e=>e.Id==Id))
                {
                    return NotFound();
                }
                else 
                {
                    throw;
                }

                
            }
            return NoContent();
        }
        

        //DELET:api/Alumnos
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteAlumno(int Id)
        {
            var alumno = await _context.Alumnos.FindAsync(Id);
            if (alumno == null) 
            {
                return NotFound();
            }
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    
    }
}
