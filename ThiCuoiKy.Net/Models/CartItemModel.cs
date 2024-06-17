 
namespace ThiCuoiKy.Net.Models
{
	public class CartItemModel
	{
		internal decimal GrandTotal;

		public int ProductId { get; set; }
		public string ProductName { get; set; }

		public int Quantity { get; set; }

		public decimal Price { get; set; }
		public decimal Total {
			get {  return Quantity*Price; }
		}
		public string Img { get; set; }
		public List<CartItemModel> CartItems { get; internal set; }

		public CartItemModel() { }

		public CartItemModel(ProductModel product)
		{ 
			ProductId = product.Id;
			ProductName = product.Name;
			Price = product.Price;
			Quantity = 1;
			Img = product.Img;
		}
	}
}
