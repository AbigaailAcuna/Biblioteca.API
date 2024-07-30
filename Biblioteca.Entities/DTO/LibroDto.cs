using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.DTO
{
    public class LibroDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del Libro es requerido")]
        [StringLength(50, ErrorMessage = "El nombre del Libro no puede tener más de 50 caracteres") ]

        public string NombreLibro { get; set; }

        [Required(ErrorMessage = "El Id del autor es requerido")]
        public int IdAutor {  get; set; }

        [Required(ErrorMessage = "El Id del editorial es requerido")]
        public int IdEditorial { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; }


    }
}
