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
    public class EditorialService : IEditorialService
    {
        private readonly IEditorialRepository repository;
        private readonly IMapper mapper;

        public EditorialService(IEditorialRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<EditorialDto>> GetEditorialesAsync()
        {
            try
            {
                var result = await repository.GetEditorialesAsync();
                return mapper.Map<List<Editorial>, List<EditorialDto>>(result);
            }
            catch (Exception ex)
            {

                return new List<EditorialDto>();
            }
        }

        public async Task<EditorialDto> GetEditorialByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetEditorialByIdAsync(id);
                return mapper.Map<Editorial, EditorialDto>(result);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<int> InsertEditorialAsync(EditorialDto model)
        {
            try
            {
                var entity = mapper.Map<EditorialDto, Editorial>(model);
                int result = await repository.InsertEditorialAsync(entity);
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
        public async Task<EditorialDto> UpdateEditorialAsync(EditorialDto model)
        {
            try
            {
                var entity = mapper.Map<EditorialDto, Editorial>(model);
                var result = await repository.UpdateEditorialAsync(entity);
                return mapper.Map<Editorial, EditorialDto>(result);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<bool> DeleteEditorialAsync(int id)
        {
            try
            {

                return await repository.DeleteEditorialAsync(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }


    }
  

}
