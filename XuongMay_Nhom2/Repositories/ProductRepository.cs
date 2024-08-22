using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public int delete(int id)
        {
            var del = _context.Products.SingleOrDefault(c => c.ProductId == id);
            if (del != null)
            {
                _context.Products.Remove(del);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public List<ProductModel> GetAll()
        {
            var list = _context.Products.Select(c => new ProductModel
            {
                ProductId = c.ProductId,
                ProductName = c.ProductName,
                Price = c.Price,
                CategoryId = c.CategoryId
            });
            return list.ToList();
        }

        public ProductModel GetById(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.ProductId == id);
            if (product != null)
                return new ProductModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };
            return null;
        }

        public void insert(ProductModel temp)
        {
            var addNew = new Product
            {
                ProductName = temp.ProductName,
                Price = temp.Price,
                CategoryId = temp.CategoryId
            };
            _context.Products.Add(addNew);
            _context.SaveChanges();
        }

        public int update(ProductModel temp)
        {
            var edit = _context.Products.SingleOrDefault(c => c.ProductId == temp.ProductId);
            if (edit != null)
            {
                edit.ProductName = temp.ProductName;
                edit.Price = temp.Price;
                edit.CategoryId = temp.CategoryId;
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
