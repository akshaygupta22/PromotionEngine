using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngine.Logic.Test
{
    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void GivenPromotionWhenAppliedThenReturnsDiscountedPrice()
        {
            Promotion promotion =
                new(new Product {Name = "A", Price = 20, IsPromotionApplied = false}, 2, 30);
            float discountedPrice = promotion.ApplyPromotion(GetProducts());

            Assert.AreEqual(50, discountedPrice);
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
