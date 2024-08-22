using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context) {
            _context = context;
        }

        public List<CategoryModel> GetAll()
        {
            var list = _context.Categories.Select(c => new CategoryModel
            {
                CategoryId  = c.CategoryId,
                CategoryName = c.CategoryName
            });
            return list.ToList();
        }

        public CategoryModel GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (category != null)
                return new CategoryModel
                {
                    CategoryName = category.CategoryName,
                    CategoryId = category.CategoryId
                };
            return null;
        }

        public void insert(CategoryModel temp)
        {
            var addNew = new Category
            {
                CategoryName = temp.CategoryName
            };
            _context.Categories.Add(addNew);
            _context.SaveChanges();
        }

        public int update(CategoryModel temp)
        {
            var edit= _context.Categories.SingleOrDefault(c=>c.CategoryId==temp.CategoryId);
            if (edit != null)
            {
                edit.CategoryName = temp.CategoryName;
                _context.SaveChanges();
                return 1;
            }
            return 0;
            
        }
        public int delete(int id)
        {
            var del = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (del != null)
            {
                _context.Categories.Remove(del);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
