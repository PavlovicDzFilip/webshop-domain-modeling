﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.WebUI.Areas.Admin.Models.DTO
{
    public class ProductOrderDTO 
    {
        [Required]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Condition { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public string UserId { get; set; }

        public string CategoryName { get; set; }

        public double GetDiscountedPrice()
        {
            return Price * (100 - Discount) / 100;
        }

        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}