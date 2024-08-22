using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public interface IOrderRepository
    {
        List<OrderModel> GetAll();
        OrderModel GetById(int id);
        void insert(OrderModel temp);
        int update(OrderModel temp);
        int delete(int id);
    }
}
