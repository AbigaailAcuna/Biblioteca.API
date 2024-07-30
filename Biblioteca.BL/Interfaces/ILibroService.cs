using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entities.DTO;

namespace Biblioteca.BL.Interfaces
{
    public interface ILibroService
    {
        public Task<List<LibroDto>> GetLibrosAsync();
        public Task<LibroDto> GetLibroByIdAsync(int id);
        public Task<int> InsertLibroAsync(LibroDto libro);
        public Task<LibroDto> UpdateLibroAsync(LibroDto libro);
        public Task<bool> DeleteLibroAsync(int id);


    }
}
