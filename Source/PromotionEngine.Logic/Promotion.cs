using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Logic
{
    public class Promotion : IPromotion
    {
        public string ProductName { get; }
        public int PromoQuantity { get; }
        public float PromotionPrice { get; }

        public Promotion(string product, int quantity, float promotionPrice)
        {
            ProductName = product;
            PromoQuantity = quantity;
            PromotionPrice = promotionPrice;
        }

        public float ApplyPromotion(Dictionary<Product, int> products)
        {
            var (product, quantity) = products.FirstOrDefault(p=>p.Key.Name == ProductName);
            if (product != null)
            {
                int promoCount = quantity / PromoQuantity;
                return (PromotionPrice * promoCount) + (product.Price * (quantity % PromoQuantity));
            }

            return 0;
        }
    }
}