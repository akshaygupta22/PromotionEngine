using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PromotionEngine.Logic.Test
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void GivenCartWhenAddProductThenProductAddedAndTotalUpdated()
        {
            Cart cart = new();
            cart.AddProduct(new Product { Name = "A", Price = 20, IsPromotionApplied = false }, 3);

            Assert.AreEqual(1, cart.Products.Count);
            Assert.AreEqual(60, cart.Total);
        }
        
        [TestMethod]
        public void GivenCartWhenAddZeroProductThenProductNotAdded()
        {
            Cart cart = new();
            cart.AddProduct(new Product { Name = "A", Price = 20, IsPromotionApplied = false }, 0);

            Assert.AreEqual(0, cart.Products.Count);
        }
        
        [TestMethod]
        public void GivenCartWhenApplyPromotionThenDiscountedTotalUpdated()
        {
            Cart cart = new();
            var product = new Product { Name = "A", Price = 20, IsPromotionApplied = false };
            cart.AddProduct(product, 3);

            Mock<IPromotion> promotionMock = new();
            promotionMock.Setup(m => m.ApplyPromotion(It.IsAny<Dictionary<Product, int>>())).Returns(50);
            //Promotion promotion = new(product, 2, 30);
            cart.ApplyPromotions(new List<IPromotion>{ promotionMock.Object });

            Assert.AreEqual(1, cart.Products.Count);
            Assert.AreEqual(60, cart.Total);
            Assert.AreEqual(50, cart.DiscountedTotal);
            promotionMock.Verify(m=>m.ApplyPromotion(It.IsAny<Dictionary<Product, int>>()), Times.Once);
        }
        
        [TestMethod]
        public void GivenPromotionAppliedWhenClearPromotionThenPromotionCleared()
        {
            Cart cart = new();
            var product = new Product { Name = "A", Price = 20, IsPromotionApplied = false };
            cart.AddProduct(product, 3);

            Mock<IPromotion> promotionMock = new();
            promotionMock.Setup(m => m.ApplyPromotion(It.IsAny<Dictionary<Product, int>>())).Returns(50);
            cart.ApplyPromotions(new List<IPromotion>{ promotionMock.Object });

            cart.ClearPromotions();

            Assert.AreEqual(1, cart.Products.Count);
            Assert.AreEqual(60, cart.Total);
            Assert.AreEqual(0, cart.DiscountedTotal);
            Assert.IsFalse(cart.Products.Keys.Any(p=>p.IsPromotionApplied));
            promotionMock.Verify(m=>m.ApplyPromotion(It.IsAny<Dictionary<Product, int>>()), Times.Once);
        }
        
        [TestMethod]
        public void GivenCartWhenClearCartThenCartCleared()
        {
            Cart cart = new();
            var product = new Product { Name = "A", Price = 20, IsPromotionApplied = false };
            cart.AddProduct(product, 3);

            cart.ClearCart();

            Assert.AreEqual(0, cart.Products.Count);
            Assert.AreEqual(0, cart.Total);
            Assert.AreEqual(0, cart.DiscountedTotal);
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
