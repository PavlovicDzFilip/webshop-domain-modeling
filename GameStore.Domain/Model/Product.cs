using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace GameStore.Domain.Model
{
    public class Product
    {
        private Product()
        {
        }

        public static Product Create(string name, int categoryId, Money price, string image, string condition, Discount discount, string userId)
        {
            var product = new Product
            {
                UserId = userId,
            };

            product.Update(name, categoryId, price, image, condition, discount);
            return product;
        }

        public void Update(string name, int categoryId, Money price, string image, string condition, Discount discount)
        {
            ProductName = name;
            CategoryId = categoryId;
            Condition = condition;
            Discount = discount;
            Image = image;
            Price = price;
        }

        public Money GetDiscountedPrice()
        {
            return Discount.ApplyOn(Price);
        }

        [Required]
        // TODO: Get back to this value later
        public int ProductId { get; private set; }
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; private set; }
        [Display(Name = "Category")]
        public int CategoryId { get; private set; }

        public double PriceValue
        {
            get => Price.Value;
            private set => Price = Money.Create(value);
        }

        [Required]
        public Money Price { get; private set; }

        [Required]
        public string Image { get; private set; }
        [Required]
        public string Condition { get; private set; }

        public int DiscountValue
        {
            get => Discount.Value;
            private set => Discount = Discount.Create(value);
        }

        [Required]
        public Discount Discount { get; private set; }
        
        [Required]
        public string UserId { get; private set; }
    }
}
