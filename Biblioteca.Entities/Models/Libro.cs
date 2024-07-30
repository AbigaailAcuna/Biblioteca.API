using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Entities.Models
{
    public class Libro
    {

        [Key]

        public int Id { get; set; }

        public required string Nombre { get; set; }

        [ForeignKey("CodigoAutor")]
        public int CodigoAutor { get; set; }
            
        [ForeignKey("CodigoEditorial")]
        public int CodigoEditorial { get; set; }
        public required DateTime FechaLanzamiento { get; set; }

        public Autor Autor { get; set; }
        public Editorial Editorial { get; set; }

    }
}
