namespace ApiPrestamoLibros.Models
{
    public class LibroModel
    {

        public int Id { get; set; }          // Identificador único
        public string Titulo { get; set; }   // Nombre del libro
        public string Autor { get; set; }    // Autor del libro
        public int Cantidad { get; set; }    // Número de copias disponibles
        public bool Activo { get; set; } = true; // Indica si está activo
    }
}
