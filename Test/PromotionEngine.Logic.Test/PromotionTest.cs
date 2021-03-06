using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Logic.Promotions;

namespace PromotionEngine.Logic.Test
{
    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void GivenPromotion1WhenAppliedThenReturnsDiscountedPrice()
        {
            Promotion1 promotion =
                new("A", 2, 30);
            var products = GetProducts();
            float discountedPrice = promotion.ApplyPromotion(products);

            Assert.AreEqual(50, discountedPrice);
            Assert.IsTrue(products.FirstOrDefault(p=>p.Key.Name == "A").Key.IsPromotionApplied);
        }

        [TestMethod]
        public void GivenPromotion3WhenAppliedThenReturnsDiscountedPrice()
        {
            Promotion3 promotion =
                new("A", 40);
            var products = GetProducts();
            float discountedPrice = promotion.ApplyPromotion(products);

            Assert.AreEqual(36, discountedPrice);
            Assert.IsTrue(products.FirstOrDefault(p => p.Key.Name == "A").Key.IsPromotionApplied);
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
