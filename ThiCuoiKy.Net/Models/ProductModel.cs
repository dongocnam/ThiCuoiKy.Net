using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ThiCuoiKy.Net.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Tên sản phẩm"), MinLength(4, ErrorMessage = "Tên sản phẩm phải có ít nhất 4 ký tự")]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Mô tả sản phẩm"), MinLength(4, ErrorMessage = "Mô tả sản phẩm phải có ít nhất 4 ký tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập giá sản phẩm")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Yêu cầu chọn thương hiệu")]
        public int BrandID { get; set; }

        [Required(ErrorMessage = "Yêu cầu chọn danh mục")]
        public int CategoryID { get; set; }

        public string Img { get; set; }

        public CategoryModel Category { get; set; }

        public BrandModel Brand { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" })]
        public IFormFile ImageUpload { get; set; }
    }

    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!_extensions.Contains(extension))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return "Chỉ chấp nhận các định dạng tệp: .jpg, .jpeg, .png, .gif";
        }
    }
}
