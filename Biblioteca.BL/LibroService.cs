using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.DTO;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository repository;
        private readonly IMapper mapper;

        public LibroService(ILibroRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<LibroDto>> GetLibrosAsync()
        {
            try
            {
                var result = await repository.GetLibrosAsync();
                return mapper.Map<List<Libro>, List<LibroDto>>(result);
            }
            catch (Exception ex)
            {

                return new List<LibroDto>();
            }
        }

        public async Task<LibroDto> GetLibroByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetLibroByIdAsync(id);
                return mapper.Map<Libro, LibroDto>(result);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<int> InsertLibroAsync(LibroDto model)
        {
            try
            {
                var entity = mapper.Map<LibroDto, Libro>(model);
                int result = await repository.InsertLibroAsync(entity);
                Console.WriteLine($"Resultado de la inserción: {result}");
                return result;
                //return await repository.InsertAutorAsync(entity);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in InsertEditorialAsync: {ex.Message}");
                return -1;
            }
        }
        public async Task<LibroDto> UpdateLibroAsync(LibroDto model)
        {
            try
            {
                var entity = mapper.Map<LibroDto, Libro>(model);
                var result = await repository.UpdateLibroAsync(entity);
                return mapper.Map<Libro, LibroDto>(result);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<bool> DeleteLibroAsync(int id)
        {
            try
            {

                return await repository.DeleteLibroAsync(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
