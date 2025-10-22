using ApiPrestamoLibros.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamoLibros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        // 🔹 Simulación de base de datos en memoria
        private static List<LibroModel> _libros = new List<LibroModel>
        {
            new LibroModel { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Cantidad = 5 },
            new LibroModel { Id = 2, Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", Cantidad = 3 }
        };

        // 16.1 → GET /api/libros
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_libros.Where(l => l.Activo).ToList());
        }

        // 16.2 → GET /api/libros/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.Id == id && l.Activo);
            if (libro == null)
                return NotFound(new { mensaje = "Libro no encontrado." });

            return Ok(libro);
        }

        // 16.3 → POST /api/libros
        [HttpPost]
        public IActionResult Create([FromBody] LibroModel nuevoLibro)
        {
            if (nuevoLibro == null)
                return BadRequest(new { mensaje = "Datos inválidos." });

            nuevoLibro.Id = _libros.Any() ? _libros.Max(l => l.Id) + 1 : 1;
            _libros.Add(nuevoLibro);

            return CreatedAtAction(nameof(GetById), new { id = nuevoLibro.Id }, nuevoLibro);
        }

        // 16.4 → PUT /api/libros/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LibroModel libroActualizado)
        {
            var libro = _libros.FirstOrDefault(l => l.Id == id && l.Activo);
            if (libro == null)
                return NotFound(new { mensaje = "Libro no encontrado." });

            libro.Titulo = libroActualizado.Titulo;
            libro.Autor = libroActualizado.Autor;
            libro.Cantidad = libroActualizado.Cantidad;

            return Ok(libro);
        }

        // 16.5 → DELETE /api/libros/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.Id == id && l.Activo);
            if (libro == null)
                return NotFound(new { mensaje = "Libro no encontrado." });

            libro.Activo = false; // lo marcamos como inactivo
            return Ok(new { mensaje = "Libro eliminado correctamente." });
        }
    }
}
