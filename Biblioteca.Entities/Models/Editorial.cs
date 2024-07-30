using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.Models
{
    public class Editorial
    {
        [Key]

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Libro> Libros { get; set; }

    }
}
