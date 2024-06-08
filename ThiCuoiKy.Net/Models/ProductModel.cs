﻿using System.ComponentModel.DataAnnotations;

namespace ThiCuoiKy.Net.Models
{
    public class ProductModel
    {

        public int Id { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Tên sản phẩm")]
		public string Name { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Mô tả sản phẩm")]

        public string Slug { get; set; }
        public string Description { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu Giá sản phẩm")]
		public decimal Price { get; set; }

        public int BrandID { get; set; }
		
		public int CategoryID { get; set; }

        public string Img { get; set; }

        public CategoryModel Category { get; set; }

        public BrandModel Brand { get; set; }
    }
}
