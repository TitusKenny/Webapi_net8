namespace WebApiApp.Models
{
    public class Momo_itemsModel
    {
        public string? id { get; set; } //SKU number
        public string? name { get; set; }//Tên sản phẩm
        public string? description { get; set; }//Miêu tả sản phẩm
        public string? category { get; set; }//	Phân loại ngành hàng của sản phẩm
        public string? imageUrl { get; set; }// Link hình ảnh của sản phẩm
        public string? manufacturer { get; set; }//Tên nhà sản xuất
        public long price { get; set; }//Đơn giá
        public string? currency { get; set; }//VND
        public int quantity { get; set; }//Số lượng của sản phẩm. Cần là một số lớn hơn 0
        public string? unit { get; set; }//Đơn vị đo lường của sản phẩm này
        public long totalPrice { get; set; }//Tổng giá = Đơn giá x Số lượng
        public long taxAmount { get; set; }//Tổng thuế
    }
}
