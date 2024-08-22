namespace XuongMay_Nhom2.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDeadline { get; set; }
        public int Status { get; set; }
        public decimal Unitprice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
    }
}
