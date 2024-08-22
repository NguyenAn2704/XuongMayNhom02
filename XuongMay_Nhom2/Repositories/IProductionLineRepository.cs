using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public interface IProductionLineRepository
    {
        List<ProductionLineModel> GetAll();
        ProductionLineModel GetById(int id);
        void insert(ProductionLineModel temp);
        int update(ProductionLineModel temp);
        int delete(int id);
    }
}
