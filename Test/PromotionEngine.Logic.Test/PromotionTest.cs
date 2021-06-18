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

        private List<Product> GetProducts()
        {
            List<Product> products = new List<Product>
            {
                new() {Name = "A", Price = 20, IsPromotionApplied = false},
                new() {Name = "A", Price = 20, IsPromotionApplied = false},
                new() {Name = "A", Price = 20, IsPromotionApplied = false}
            };
            return products;
        }
    }
}
