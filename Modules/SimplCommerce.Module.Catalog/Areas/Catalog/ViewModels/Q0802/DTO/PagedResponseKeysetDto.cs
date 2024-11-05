using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802.DTO
{
    public record PagedResponseKeysetDto<T>
    {
        public long Reference { get; set; }

        public IList<T> Data { get; set; }

        public PagedResponseKeysetDto(List<T> data, long reference)
        {
            Data = data;
            Reference = reference;
        }
    }
}
