using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public interface ITaskRepository
    {
        List<TaskModel> GetAll();
        TaskModel GetById(int id);
        void insert(TaskModel temp);
        int update(TaskModel temp);
        int delete(int id);
    }
}
