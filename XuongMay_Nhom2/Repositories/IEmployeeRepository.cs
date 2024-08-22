using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public interface IEmployeeRepository
    {
        List<EmployeeModel> GetAll();
        EmployeeModel GetById(int id);
        void insert(EmployeeModel temp);
        int update(EmployeeModel temp);
        int delete(int id);
    }
}
