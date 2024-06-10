using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiCuoiKy.Net.Models
{
    public class ProductModel
    {

        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Tên sản phẩm")]
        public string Name { get; set; }

        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Mô tả sản phẩm")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập giá sản phẩm")]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName ="decima(8, 2)")]
        public decimal Price { get; set; }
        public int BrandID { get; set; }

        public int CategoryID { get; set; }

        public string Img { get; set; }

        public CategoryModel Category { get; set; }

        public BrandModel Brand { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [FileExtensions]

        public IFormFile ImageUpload { get; set; }
    }
}
