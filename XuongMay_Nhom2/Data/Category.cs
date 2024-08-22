using System.ComponentModel.DataAnnotations;

namespace XuongMay_Nhom2.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
