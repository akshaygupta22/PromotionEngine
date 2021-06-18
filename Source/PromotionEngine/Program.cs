using System;
using System.Collections;
using System.Collections.Generic;
using PromotionEngine.Logic;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new();

            Console.WriteLine("Scenario 1");
            AddProductsToCart(cart, GetProducts1());
            cart.ApplyPromotions(GetPromotions1());
            cart.Checkout();

            Console.WriteLine("Scenario 2");
            cart.ClearCart();
            AddProductsToCart(cart, GetProducts2());
            cart.ApplyPromotions(GetPromotions2());
            cart.Checkout();

            Console.WriteLine("Scenario 3");
            cart.ClearCart();
            AddProductsToCart(cart, GetProducts3());
            cart.ApplyPromotions(GetPromotions3());
            cart.Checkout();

        }

        private static void AddProductsToCart(Cart cart, Dictionary<Product, int> products)
        {
            foreach ((Product product, int quantity) in products)
            {
                cart.AddProduct(product, quantity);
            }
        }

        #region scenario 1

        private static List<IPromotion> GetPromotions1()
        {
            return new()
            {
                new Promotion1("A", 3, 130),
                new Promotion1("B", 2, 45),
                new Promotion2("C", "D", 30),
            };
        }

        private static Dictionary<Product, int> GetProducts1()
        {
            Dictionary<Product, int> products = new()
            {
                { new() { Name = "A", Price = 50 }, 1 },
                { new() { Name = "B", Price = 30 }, 1 },
                { new() { Name = "C", Price = 20 }, 1 }
            };
            return products;
        }

        #endregion

        #region scenario 2

        private static List<IPromotion> GetPromotions2()
        {
            return new()
            {
                new Promotion1("A", 3, 130),
                new Promotion1("B", 2, 45),
                new Promotion2("C", "D", 30),
            };
        }

        private static Dictionary<Product, int> GetProducts2()
        {
            Dictionary<Product, int> products = new()
            {
                { new() { Name = "A", Price = 50 }, 5 },
                { new() { Name = "B", Price = 30 }, 5 },
                { new() { Name = "C", Price = 20 }, 1 }
            };
            return products;
        }

        #endregion

        #region scenario 3
        
        private static List<IPromotion> GetPromotions3()
        {
            return new()
            {
                new Promotion1("A", 3, 130),
                new Promotion1("B", 2, 45),
                new Promotion2("C", "D", 30),
            };
        }

        private static Dictionary<Product, int> GetProducts3()
        {
            Dictionary<Product, int> products = new()
            {
                { new() { Name = "A", Price = 50 }, 3 },
                { new() { Name = "B", Price = 30 }, 5 },
                { new() { Name = "C", Price = 20 }, 1 },
                { new() { Name = "D", Price = 15 }, 1 }
            };
            return products;
        }

        #endregion

    }
}
