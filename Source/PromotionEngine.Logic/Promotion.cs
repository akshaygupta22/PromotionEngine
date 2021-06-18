using System.Collections.Generic;

namespace PromotionEngine.Logic
{
    public class Promotion : IPromotion
    {
        public Product Product { get; }
        public int Quantity { get; }
        public float PromotionPrice { get; }

        public Promotion(Product product, int quantity, float promotionPrice)
        {
            Product = product;
            Quantity = quantity;
            PromotionPrice = promotionPrice;
        }

        public float ApplyPromotion(List<Product> products)
        {
            throw new System.NotImplementedException();
        }
    }
}