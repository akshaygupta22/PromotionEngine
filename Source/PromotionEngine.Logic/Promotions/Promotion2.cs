using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Logic.Interfaces;

namespace PromotionEngine.Logic.Promotions
{
    public class Promotion2 : IPromotion
    {
        public string ProductName1 { get; }
        public string ProductName2 { get; }
        public float PromotionPrice { get; }

        public Promotion2(string product1, string product2, float promotionPrice)
        {
            ProductName1 = product1;
            ProductName2 = product2;
            PromotionPrice = promotionPrice;
        }

        public float ApplyPromotion(Dictionary<Product, int> products)
        {
            var (product1, quantity1) = products.FirstOrDefault(p=>p.Key.Name == ProductName1);
            var (product2, quantity2) = products.FirstOrDefault(p=>p.Key.Name == ProductName2);
            float discountedPrice = 0;
            if (product1 != null && product2 != null)
            {
                int promoCount = quantity1 > quantity2 ? quantity2 : quantity1;
                discountedPrice = (PromotionPrice * promoCount) + (quantity1 > quantity2
                    ? (quantity1 - quantity2) * product1.Price
                    : (quantity2 - quantity1) * product2.Price);

                product1.IsPromotionApplied = true;
                product2.IsPromotionApplied = true;
            }
            else if(product1 != null)
            {
                discountedPrice = (product1.Price * quantity1);
                product1.IsPromotionApplied = true;
            }
            else if(product2 != null)
            {
                discountedPrice = (product2.Price * quantity2);
                product2.IsPromotionApplied = true;
            }

            return discountedPrice;
        }
    }
}