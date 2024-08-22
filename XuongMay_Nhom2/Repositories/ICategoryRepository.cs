using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryModel> GetAll();
        CategoryModel GetById(int id);
        void insert(CategoryModel temp);
        int update(CategoryModel temp);
        int delete(int id);
    }
}
