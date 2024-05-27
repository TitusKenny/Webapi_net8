using Azure.Core;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace WebApiApp.Models
{
    public class MomoVM
    {
        public string? partnerCode { get; set; } //Thông tin tích hợp
        public string? subPartnerCode { get; set; } //Định danh duy nhất của tài khoản M4B của bạn
        public string? storeId { get; set; } //Mã cửa hàng
        public string? storeName { get; set; } //Tên cửa hàng
        public string? orderId { get; set; } //Mã đơn hàng của đối tác
        public string? amount { get; set; } // Số tiền cần thanh toán VND MIN 1000- MAX 5.000.000
        [Required]
        [MaxLength(50)]
        public string? requestId { get; set; } //Định danh duy nhất cho mỗi yêu cầu, Đối tác sử dụng requestId cho xử lý idempotency
        public string? paymentCode { get; set; } //Payment code được tạo từ app MoMo mà được scanned bởi thu ngân sử dụng public Key và thuật toán RSA Encryption
        public string? orderInfo { get; set; } //Thông tin hóa đơn
        public long orderGroupId { get; set; } //được cung cấp bởi MoMo để sắp xếp các nhóm của các hóa đơn cho các hoạt động vận hành sau đó. Liên hệ MoMo để có thể sử dụng field này.
        public Boolean autoCapture { get; set; } = true; //Nếu giá trị false, giao dịch sẽ không tự động capture. Mặc định là true
        public string? ipnUrl { get; set; } //API của đối tác. Được MoMo sử dụng để gửi kết quả thanh toán theo phương thức (server-to-server)
        public string? extraData { get; set; } //Giá trị mặc định là rỗng"" ,Encode base64 theo định dạng Json: {"key": "value"}
        public object? userInfo { get; set; } //Thông tin người dùng
        public List<Momo_itemsModel>? items { get; set; } //Danh sách các sản phẩm hiển thị trên trang thanh toán. Max 50
        public long requestTime { get; set; } //Thời gian đối tác gửi yêu cầu đến MoMo. Định dạng: timestamp
        public string? lang { get; set; } //Ngôn ngữ của message được trả về (vi or en)
        public string? signature { get; set; } //Chữ ký để xác nhận giao dịch. sử dụng thuật toán Hmac_SHA256 với data theo định dạng: 1 chuỗi String được sort theo thứ tự alphabet
        //accessKey=$accessKey&amount=$amount&extraData=$extraData&orderId=$orderId //&orderInfo=$orderInfo&partnerCode=$partnerCode // &paymentCode=$paymentCode&requestId=$requestId
    }
    public class MomoModel
    {
        //body của ipnUrl 
        public string? partnerCode { get; set; } //Thông tin tích hợp
        public string? orderId { get; set; } //Mã đơn hàng của đối tác
        public string? requestId { get; set; } //Partner's requestId
        public long amount { get; set; } //Số tiền cần thanh toán
        public string? orderInfo { get; set; } //Thông tin hóa đơn
        public string? partnerUserId { get; set; } //Định danh duy nhất của MoMo cho mỗi tài khoản ví MoMo.
        public string? orderType { get; set; } //momo_wallet
        public long transId { get; set; } //MoMo's transaction ID
        public int resultCode { get; set; } //Trạng thái giao dịch của hóa đơn Result Code
        public string? message { get; set; } //Mô tả kết quả, ngôn ngữ dựa trên lang
        public string? payType { get; set; } //Mặc định: pos
        public long responseTime { get; set; } //Thời gian phản hồi kết quả giao dịch đến đối tác Định dạng: timestamp
        public string? extraData { get; set; } //	Extra Data. Default: ""
        public string? signature { get; set; } //Chữ ký để xác nhận giao dịch. sử dụng thuật toán Hmac_SHA256 với data theo định dạng: 1 chuỗi String được sort theo thứ tự alphabet
        //accessKey=$accessKey&amount=$amount&extraData=$extraData&orderId=$orderId //&orderInfo=$orderInfo&partnerCode=$partnerCode // &paymentCode=$paymentCode&requestId=$requestId
    }
}
