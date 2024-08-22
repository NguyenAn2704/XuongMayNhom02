using XuongMay_Nhom2.Data;

namespace XuongMay_Nhom2.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
