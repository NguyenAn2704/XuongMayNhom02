using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public interface IProductRepository
    {
        List<ProductModel> GetAll();
        ProductModel GetById(int id);
        void insert(ProductModel temp);
        int update(ProductModel temp);
        int delete(int id);
    }
}
