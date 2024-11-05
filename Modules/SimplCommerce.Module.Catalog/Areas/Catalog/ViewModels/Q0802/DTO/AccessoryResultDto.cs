using System;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802.DTO
{
    public class AccessoryResultDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }

        public int? StockQuantity { get; set; }

        public DateTimeOffset? SpecialPriceStart { get; set; }

        public DateTimeOffset? SpecialPriceEnd { get; set; }

        public int ReviewsCount { get; set; }

        public double? RatingAverage { get; set; }

        public string ImgName { get; set; }
    }
}
