using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.Models;
using Dapper;

namespace Biblioteca.DAL
{
    public class LibroRepository : ILibroRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public LibroRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Libro>> GetLibrosAsync()
        {
            string query = "SELECT * FROM Libros";
            return await databaseRepository.GetDataByQueryAsync<Libro>(query);
        }
        public async Task<Libro> GetLibroByIdAsync(int id)
        {
            string query = "SELECT * FROM Libros WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Libro>(query, parameters)).FirstOrDefault();
        }
        public async Task<int> InsertLibroAsync(Libro libro)
        {
            string query = "INSERT INTO Libros (Id, Nombre, CodigoAutor, CodigoEditorial, FechaLanzamiento) VALUES (@Id,@Nombre, @CodigoAutor, @CodigoEditorial, @FechaLanzamiento) ";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", libro.Id);
            parameters.Add("@Nombre", libro.Nombre);
            parameters.Add("@CodigoAutor", libro.CodigoAutor);
            parameters.Add("@CodigoEditorial", libro.CodigoEditorial);
            parameters.Add("@FechaLanzamiento", libro.FechaLanzamiento);
            return await databaseRepository.InsertAsync(query, parameters);

        }
        public async Task<Libro> UpdateLibroAsync(Libro libro)
        {
            string query = "UPDATE Libros SET Nombre = @Nombre, CodigoAutor = @CodigoAutor, CodigoEditorial = @CodigoEditorial, FechaLanzamiento = @FechaLanzamiento WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", libro.Id);
            parameters.Add("@Nombre", libro.Nombre);
            parameters.Add("@CodigoAutor", libro.CodigoAutor);
            parameters.Add("@CodigoEditorial", libro.CodigoEditorial);
            parameters.Add("@FechaLanzamiento", libro.FechaLanzamiento);
            await databaseRepository.Update<Libro>(query, parameters);
            return libro;

        }
        public async Task<bool> DeleteLibroAsync(int id)
        {
            string query = "DELETE FROM Libros WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.Delete(query, parameters);


        }



    }
}
