using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public interface IRoleRepository
    {
        List<RoleModel> GetAll();
        RoleModel GetById(int id);
        void insert(RoleModel temp);
        int update(RoleModel temp);
        int delete(int id);
    }
}
