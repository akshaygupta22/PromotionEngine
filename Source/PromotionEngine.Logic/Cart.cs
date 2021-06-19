using System;
using System.Collections.Generic;
using PromotionEngine.Logic.Interfaces;

namespace PromotionEngine.Logic
{
    public class Cart : ICart
    {
        public Dictionary<Product, int> Products { get; }
        public float Total { get; private set; }
        public float TotalDiscount { get; private set; }
        public float DiscountedTotal { get; set; }

        private bool _isPromotionsApplied;

        public Cart()
        {
            Products = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int quantity)
        {
            if(quantity <= 0)
            {
                Console.WriteLine("Cannot add 0 products.");
                return;
            }
            Products.Add(product, quantity);
            Total += (product.Price * quantity);
        }
        
        public void ClearCart()
        {
            Products.Clear();
            Total = 0;
            DiscountedTotal = 0;
            TotalDiscount = 0;
            _isPromotionsApplied = false;
        }

        public void ClearPromotions()
        {
            if (_isPromotionsApplied)
            {
                foreach (var (product, _) in Products)
                {
                    product.IsPromotionApplied = false;
                }
                DiscountedTotal = 0;
                TotalDiscount = 0;
            }
        }

        public void ApplyPromotions(List<IPromotion> promotions)
        {
            if (!_isPromotionsApplied)
            {
                foreach (var promotion in promotions)
                {
                    DiscountedTotal += promotion.ApplyPromotion(Products);
                }
                _isPromotionsApplied = true;
            }
        }

        public void Checkout()
        {
            foreach (var (product, quantity) in Products)
            {
                Console.WriteLine($"Product : {product.Name} Price : {product.Price} Quantity : {quantity}");
            }
            Console.WriteLine($"Total : {Total}");
            Console.WriteLine($"Discount : {TotalDiscount = Total - DiscountedTotal}");
            Console.WriteLine($"Discounted Total : {DiscountedTotal}");
        }
    }
}