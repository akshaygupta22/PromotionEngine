using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Logic
{
    public class Promotion3 : IPromotion
    {
        public string ProductName { get; }
        public float PromotionDiscount { get; }

        public Promotion3(string product1, float promotionPrice)
        {
            ProductName = product1;
            PromotionDiscount = promotionPrice;
        }

        public float ApplyPromotion(Dictionary<Product, int> products)
        {
            var (product, quantity) = products.FirstOrDefault(p=>p.Key.Name == ProductName);
            float discountedPrice = 0;
            if(product != null)
            {
                discountedPrice = (product.Price-(product.Price * (PromotionDiscount/100))) * quantity;
                product.IsPromotionApplied = true;
            }

            return discountedPrice;
        }
    }
}