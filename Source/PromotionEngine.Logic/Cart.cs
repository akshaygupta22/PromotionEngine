using System;
using System.Collections.Generic;

namespace PromotionEngine.Logic
{
    public class Cart : ICart
    {
        public List<Product> Products { get; }
        public float Total { get; private set; }
        public float TotalDiscount { get; private set; }
        public float DiscountedTotal { get; set; }

        private bool _isPromotionsApplied;

        public Cart()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            Total += product.Price;
        }
        
        public void ClearCart()
        {
            Products.Clear();
            Total = 0;
            DiscountedTotal = 0;
            TotalDiscount = 0;
        }

        public void ClearPromotions()
        {
            if (_isPromotionsApplied)
            {
                Products.ForEach(p => p.IsPromotionApplied = false);
                DiscountedTotal = 0;
                TotalDiscount = 0;
            }
        }

        public void ApplyPromotions(List<Promotion> promotions)
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
            foreach (var product in Products)
            {
                Console.WriteLine($"Product : {product.Name} Price : {product.Price}");
            }
            Console.WriteLine($"Total : {Total}");
        }
    }
}