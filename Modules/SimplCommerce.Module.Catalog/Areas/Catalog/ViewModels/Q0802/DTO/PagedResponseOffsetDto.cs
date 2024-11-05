using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802.DTO
{
    public record PagedResponseOffset<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPage { get; set; }

        public int TotalRecords { get; set; }

        public IList<T> Data { get; set; }

        public PagedResponseOffset(IList<T> data, int pageNumber, int pageSize, int totalRecords)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = (int)(Math.Ceiling((decimal)totalRecords / (decimal)pageSize));
        }
    }
}
