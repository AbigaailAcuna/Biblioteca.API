using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entities.DTO;

namespace Biblioteca.BL.Interfaces
{
    public interface IEditorialService
    {

        public Task<List<EditorialDto>> GetEditorialesAsync();
        public Task<EditorialDto> GetEditorialByIdAsync(int id);
        public Task<int> InsertEditorialAsync(EditorialDto editorial);
        public Task<EditorialDto> UpdateEditorialAsync(EditorialDto editorial);
        public Task<bool> DeleteEditorialAsync(int id);

    } 
}
