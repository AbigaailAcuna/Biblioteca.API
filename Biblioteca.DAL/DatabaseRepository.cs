using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Common;
using Biblioteca.DAL.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Biblioteca.DAL
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string connectionString;
        public DatabaseRepository(IOptions<AppSettings> appSettings)
        {
            connectionString = appSettings.Value.ConnectionString;
        }

        public async Task<List<T>> GetDataByQueryAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var conection = new SqlConnection(connectionString))
                {
                    conection.Open();
                    var result = await conection.QueryAsync<T>(query, parameters);
                    conection.Close();
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error en GetDataByQuery : " + ex.Message);
            }
        }

        public async Task<int> InsertAsync(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var conection = new SqlConnection(connectionString))
                {
                    conection.Open();
                    int result = await conection.QuerySingleOrDefaultAsync<int>(query, parameters);
                    conection.Close();
                    Console.WriteLine("result agregar en clase Biblioteca.DAL"+ result);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error en insertar : " + ex.Message);
            }
        }

        public async Task<T> Update<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var conection = new SqlConnection(connectionString))
                {
                    conection.Open();
                    var result = await conection.QueryAsync<T>(query, parameters);
                    conection.Close();
                    if(result != null && result.Any())
                    {
                        return result.FirstOrDefault();
                    }
                   
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error en consulta de actualizar : " + ex.Message);
            }
            return default;
        }

        public async Task<bool> Delete(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int rowsAffected = await connection.ExecuteAsync(query, parameters);
                    Console.WriteLine($"Filas afectadas: {rowsAffected}");
                    return rowsAffected > 0; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en consulta de eliminar: " + ex.Message);
            }
        }




    }
}
