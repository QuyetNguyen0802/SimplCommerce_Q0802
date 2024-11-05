using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802.DTO;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Services
{
    public class AccessoryService : IAccessoryService
    {
        private readonly IRepository<Accessory> _accessoryRepository;

        public AccessoryService(IRepository<Accessory> accessoryReposity)
        {
            _accessoryRepository = accessoryReposity;
        }

        public async Task<PagedResponseOffset<Accessory>> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            var totalRecords = await _accessoryRepository.Query().AsNoTracking().CountAsync();

            var accessories = await _accessoryRepository.Query().AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var pagedRespone = new PagedResponseOffset<Accessory>(accessories, pageNumber, pageSize, totalRecords);

            return pagedRespone;
        }

        public async Task<PagedResponseKeysetDto<Accessory>> GetWithKeysetPagination(int reference, int pageSize)
        {
            var accessories = await _accessoryRepository.Query().AsNoTracking()
                .OrderBy(x => x.Id)
                .Where(q => q.Id > reference)
                .Take(pageSize)
                .ToListAsync();

            var newReference = accessories.Count != 0 ? accessories.Last().Id : 0;

            var pagedRespone = new PagedResponseKeysetDto<Accessory>(accessories, newReference);

            return pagedRespone;
        }

        public IList<Accessory> GetAll()
        {
            var accessories = _accessoryRepository.Query().ToList();


            return accessories;
        }
        public void Create(Accessory accessory)
        {
            using (var transaction = _accessoryRepository.BeginTransaction())
            {
                _accessoryRepository.Add(accessory);
                _accessoryRepository.SaveChanges();

                transaction.Commit();
            }
        }

        public void Update(Accessory accessory)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Accessory accessory)
        {
            throw new NotImplementedException();
        }
    }
}
