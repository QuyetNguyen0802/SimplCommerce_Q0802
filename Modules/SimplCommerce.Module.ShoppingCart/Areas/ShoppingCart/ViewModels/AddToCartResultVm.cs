﻿using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels
{
    public class AddToCartResultVm
    {
        private readonly ICurrencyService _currencyService;

        public AddToCartResultVm(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public CalculatedProductPrice CalculatedProductPrice { get; set; }

        public decimal ProductPrice { get; set; }

        public string VariationName { get; set; }

        public int Quantity { get; set; }

        public int CartItemCount { get; set; }

        public decimal CartAmount { get; set; }

        public string ProductPriceString => _currencyService.FormatCurrency(ProductPrice);

        public string CartAmountString => _currencyService.FormatCurrency(CartAmount);
    }
}
