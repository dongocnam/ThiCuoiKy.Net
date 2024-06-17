using Microsoft.EntityFrameworkCore;
using ThiCuoiKy.Net.Models;

namespace ThiCuoiKy.Net.Repository
{
	public class SeedData
	{
		public static void SeedingData(DataContext _context)
		{
			_context.Database.Migrate();
			if(!_context.Products.Any() )
			{
				//CategoryModel caneon =new CategoryModel {Name="Cá Neon", Slug= "caneon", Description= "Cá Neon: Nổi bật với vệt màu neon rực rỡ, hiền hòa, dễ nuôi, thích hợp cho bể thủy sinh.", Status=1  };
				//CategoryModel cacauvong =new CategoryModel {Name="Cá Cầu Vồng", Slug= "cacauvong", Description= "Cá cầu vồng: Nổi tiếng với sắc màu rực rỡ, hiền hòa, ưa thích dòng nước mạnh, đòi hỏi hồ rộng và nhiều cây thủy sinh.", Status=1  };
				//CategoryModel caphuonghoang =new CategoryModel {Name= "Cá Phượng Hoàng", Slug= "caphuonghoang", Description= "Cá Phượng Hoàng: Nổi bật với vây dài mềm mại, rực rỡ sắc màu, hiền hòa, dễ nuôi, thích hợp bể thủy sinh.", Status=1  };
				//CategoryModel cabetta =new CategoryModel {Name= "Cá Betta", Slug= "cabetta", Description= "Cá Betta: Nổi tiếng với vẻ ngoài rực rỡ, hiếu chiến, thích hợp nuôi đơn lẻ, đòi hỏi ít không gian và dễ chăm sóc.", Status=1  };
				//CategoryModel cathantien =new CategoryModel {Name= "Cá Thần Tiên", Slug= "cathantien", Description= "Cá thần tiên: Nổi tiếng với thân hình thanh mảnh, màu sắc đa dạng, tính cách hiền hòa, dễ nuôi, thích hợp cho bể thủy sinh lớn.", Status=1  };
				//CategoryModel tepthuysinh =new CategoryModel {Name= "Tép Thủy Sinh", Slug= "tepthuysinh", Description= "Tép thủy sinh: Nhỏ nhắn, đa dạng màu sắc, hiền hòa, dễ nuôi, dọn rêu tốt, thích hợp cho bể thủy sinh nhỏ.", Status=1  };
				//CategoryModel thucanca =new CategoryModel {Name= "Thức Ăn Cá", Slug= "tepthuysinh", Description= "Thức ăn cá cung cấp dinh dưỡng cần thiết cho cá phát triển khỏe mạnh, bao gồm các loại thức ăn dạng viên, bột, trùn chỉ, artemia, phù hợp với từng loại cá và giai đoạn phát triển.", Status=1  };
				//CategoryModel hothuysinh =new CategoryModel {Name= "Hồ Thủy Sinh", Slug= "hothuysinh", Description= "Hồ thủy sinh: Hệ sinh thái thu nhỏ dưới nước trong bể kính, mang đến vẻ đẹp, sự đa dạng và lợi ích cho sức khỏe.", Status=1  };
				//BrandModel cacanh =new BrandModel { Name = "Cá Cảnh", Slug = "cacanh", Description = "Cá cảnh: Đa dạng, đẹp mắt, mang đến sự thư giãn, dễ nuôi, thích hợp cho mọi không gian, giúp giảm căng thẳng và cải thiện tâm trạng.", Status = 1 };
				//BrandModel phukien = new BrandModel { Name="Phụ Kiện", Slug= "phukien", Description= "Phụ kiện cá cảnh gồm thức ăn cá giúp cung cấp dinh dưỡng và hồ thủy sinh tạo môi trường sống tự nhiên cho cá.", Status=1  };
				_context.Products.AddRange(
					//new ProductModel { Name = "Cá Neon", Slug = "caneon", Description = "Cá Neon: Nổi bật với vệt màu neon rực rỡ, hiền hòa, dễ nuôi, thích hợp cho bể thủy sinh.", Img = "canneon.png", Category = caneon, Brand =cacanh , Price = 10 },
					//new ProductModel { Name = "Cá Cầu Vồng", Slug = "cacauvong", Description = "Cá cầu vồng: Nổi tiếng với sắc màu rực rỡ, hiền hòa, ưa thích dòng nước mạnh, đòi hỏi hồ rộng và nhiều cây thủy sinh.", Img = "cacauvong.jgp", Category = cacauvong, Brand = cacanh, Price = 15 },
					//new ProductModel { Name = "Cá Phượng Hoàng", Slug = "caphuonghoang", Description = "Cá Phượng Hoàng: Nổi bật với vây dài mềm mại, rực rỡ sắc màu, hiền hòa, dễ nuôi, thích hợp bể thủy sinh.", Img = "caphuonghoang.jgp", Category = caphuonghoang, Brand = cacanh, Price = 20 },
					//new ProductModel { Name = "Cá Betta", Slug = "cabetta", Description = "Cá Betta: Nổi tiếng với vẻ ngoài rực rỡ, hiếu chiến, thích hợp nuôi đơn lẻ, đòi hỏi ít không gian và dễ chăm sóc.", Img = "cabetta.jpg", Category = cabetta, Brand = cacanh, Price = 10 },
					//new ProductModel { Name = "Cá Thần Tiên", Slug = "cathantien", Description = "Cá thần tiên: Nổi tiếng với thân hình thanh mảnh, màu sắc đa dạng, tính cách hiền hòa, dễ nuôi, thích hợp cho bể thủy sinh lớn.", Img = "cathantien.jgp", Category = cathantien, Brand = cacanh, Price = 12 },
					//new ProductModel { Name = "Tép Thủy Sinh", Slug = "tepthuysinh", Description = "Cá thần tiên: Nổi tiếng với thân hình thanh mảnh, màu sắc đa dạng, tính cách hiền hòa, dễ nuôi, thích hợp cho bể thủy sinh lớn.", Img = "tepthuysinh.jgp", Category = tepthuysinh, Brand = cacanh, Price = 17 },
					//new ProductModel { Name = "Thức Ăn Cá", Slug = "thucanca", Description = "Thức ăn cá cung cấp dinh dưỡng cần thiết cho cá phát triển khỏe mạnh, bao gồm các loại thức ăn dạng viên, bột, trùn chỉ, artemia, phù hợp với từng loại cá và giai đoạn phát triển.", Img = "thucanca.jgp", Category = thucanca, Brand = phukien, Price = 7 },
					//new ProductModel { Name = "Hồ Thủy Sinh", Slug = "hothuysinh", Description = "Hồ thủy sinh: Hệ sinh thái thu nhỏ dưới nước trong bể kính, mang đến vẻ đẹp, sự đa dạng và lợi ích cho sức khỏe.", Img = "thucanca.jgp", Category = hothuysinh, Brand = phukien, Price =10 }
				);
				_context.SaveChanges();
			}
		}
	}
}
