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
    public class EditorialRepository : IEditorialRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public EditorialRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }
        public async Task<List<Editorial>> GetEditorialesAsync()
        {
            string query = "SELECT * FROM Editoriales";
            return await databaseRepository.GetDataByQueryAsync<Editorial>(query);
        }
        public async Task<Editorial> GetEditorialByIdAsync(int id)
        {
            string query = "SELECT * FROM Editoriales WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Editorial>(query, parameters)).FirstOrDefault();
        }
        public async Task<int> InsertEditorialAsync(Editorial editorial)
        {
            string query = "INSERT INTO Editoriales (Id, Nombre) VALUES (@Id,@Nombre) ";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", editorial.Id);
            parameters.Add("@Nombre", editorial.Nombre);
            return await databaseRepository.InsertAsync(query, parameters);

        }
        public async Task<Editorial> UpdateEditorialAsync(Editorial editorial)
        {
            string query = "UPDATE Editoriales SET Nombre = @Nombre WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", editorial.Id);
            parameters.Add("@Nombre", editorial.Nombre);
            await databaseRepository.Update<Editorial>(query, parameters);
            return editorial;

        }
        public async Task<bool> DeleteEditorialAsync(int id)
        {
            string query = "DELETE FROM Editoriales WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.Delete(query, parameters);


        }

    }
}
