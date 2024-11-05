using System.Collections.Generic;
using System.Threading.Tasks;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802.DTO;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Services
{
    public interface IAccessoryService
    {

        Task<PagedResponseOffset<Accessory>> GetWithOffsetPagination(int pageNumber, int pageSize);

        Task<PagedResponseKeysetDto<Accessory>> GetWithKeysetPagination(int reference, int pageSize);

        IList<Accessory> GetAll();
        void Create(Accessory accessory);

        void Update(Accessory accessory);

        Task Delete(long id);

        Task Delete(Accessory accessory);

    }
}
