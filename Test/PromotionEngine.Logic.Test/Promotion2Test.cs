using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngine.Logic.Test
{
    [TestClass]
    public class Promotion2Test
    {
        [TestMethod]
        public void GivenPromotion2WhenAppliedThenReturnsDiscountedPrice()
        {
            Promotion2 promotion =
                new("A", "B", 20);
            var products = GetProducts();
            float discountedPrice = promotion.ApplyPromotion(products);

            Assert.AreEqual(60, discountedPrice);
            Assert.IsTrue(products.FirstOrDefault(p=>p.Key.Name == "A" || p.Key.Name == "B").Key.IsPromotionApplied);
        }
        
        [TestMethod]
        public void GivenPromotion2AndOnly1ProductWhenAppliedThenReturnsActualPrice()
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>()
            {
                {new() {Name = "A", Price = 20, IsPromotionApplied = false}, 3},
                { new() {Name = "C", Price = 30, IsPromotionApplied = false}, 1}
            };
            Promotion2 promotion =
                new("A", "B", 20);
            float discountedPrice = promotion.ApplyPromotion(products);

            Assert.AreEqual(60, discountedPrice);
            Assert.IsTrue(products.FirstOrDefault(p=>p.Key.Name == "A" || p.Key.Name == "B").Key.IsPromotionApplied);
        }

        [TestMethod]
        public void GivenPromotion2AndOnly2ndProductWhenAppliedThenReturnsActualPrice()
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>()
            {
                {new() {Name = "B", Price = 10, IsPromotionApplied = false}, 1},
                { new() {Name = "C", Price = 30, IsPromotionApplied = false}, 1}
            };
            Promotion2 promotion =
                new("A", "B", 20);
            float discountedPrice = promotion.ApplyPromotion(products);

            Assert.AreEqual(10, discountedPrice);
            Assert.IsTrue(products.FirstOrDefault(p=>p.Key.Name == "A" || p.Key.Name == "B").Key.IsPromotionApplied);
        }
        
        private Dictionary<Product, int> GetProducts()
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>()
            {
                {new() {Name = "A", Price = 20, IsPromotionApplied = false}, 3},
                {new() {Name = "B", Price = 10, IsPromotionApplied = false}, 1},
                { new() {Name = "C", Price = 30, IsPromotionApplied = false}, 1}
            };
            return products;
        }
    }
}
