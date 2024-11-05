using AutoMapper;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802.DTO;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802.Mappers
{
    public class AccessoryProfile : Profile
    {
        public AccessoryProfile()
        {
            CreateMap<Accessory, AccessoryResultDto>();
        }
    }
}
