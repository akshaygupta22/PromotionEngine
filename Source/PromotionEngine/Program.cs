using System;
using System.Collections.Generic;
using PromotionEngine.Logic;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new();
            foreach ((Product product, int quantity) in GetProducts())
            {
                cart.AddProduct(product, quantity);
            }

            cart.ApplyPromotions(GetPromotions());
            cart.Checkout();
        }

        private static List<IPromotion> GetPromotions()
        {
            return new()
            {
                new Promotion1("A", 3, 130),
                new Promotion1("B", 2, 45),
                new Promotion2("C", "D", 30),
            };
        }

        private static Dictionary<Product, int> GetProducts()
        {
            Dictionary<Product, int> products = new()
            {
                {new() {Name = "A", Price = 50}, 3},
                {new() {Name = "B", Price = 30}, 5},
                {new() {Name = "C", Price = 20}, 1},
                {new() {Name = "D", Price = 15}, 1}
            };
            return products;
        }
        
    }
}
