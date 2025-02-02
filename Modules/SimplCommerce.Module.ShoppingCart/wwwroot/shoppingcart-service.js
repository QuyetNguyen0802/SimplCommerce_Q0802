﻿(function() {
    angular
        .module('simpl.shoppingCart')
        .factory('shoppingCartService', [
            '$http',
            function ($http) {
                function getShoppingCartItems() {
                    return $http.get('cart/list');
                }
                
                function removeShoppingCartItem(itemId) {
                    return $http.post('cart/remove-item', itemId);
                }

                function updateQuantity(itemId, quantity) {
                    return $http.post('cart/update-item-quantity', {
                        cartItemId: itemId,
                        quantity: quantity
                    });
                }

                function applyCoupon(couponCode) {
                    return $http.post('cart/apply-coupon', { couponCode: couponCode });
                }

                return {
                    getShoppingCartItems: getShoppingCartItems,
                    removeShoppingCartItem: removeShoppingCartItem,
                    updateQuantity: updateQuantity,
                    applyCoupon: applyCoupon
                };
            }
        ]);
})();
