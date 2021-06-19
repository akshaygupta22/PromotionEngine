using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Logic.Interfaces;

namespace PromotionEngine.Logic.Promotions
{
    public class Promotion1 : IPromotion
    {
        public string ProductName { get; }
        public int PromoQuantity { get; }
        public float PromotionPrice { get; }

        public Promotion1(string product, int quantity, float promotionPrice)
        {
            ProductName = product;
            PromoQuantity = quantity;
            PromotionPrice = promotionPrice;
        }

        public float ApplyPromotion(Dictionary<Product, int> products)
        {
            var (product, quantity) = products.FirstOrDefault(p=>p.Key.Name == ProductName);
            float discountedPrice = 0;
            if (product != null)
            {
                int promoCount = quantity / PromoQuantity;
                if(promoCount >= 1)
                {
                    discountedPrice = (PromotionPrice * promoCount) + (product.Price * (quantity % PromoQuantity));
                }
                else
                {
                    discountedPrice = product.Price * quantity;
                }

                product.IsPromotionApplied = true;
            }

            return discountedPrice;
        }
    }
}