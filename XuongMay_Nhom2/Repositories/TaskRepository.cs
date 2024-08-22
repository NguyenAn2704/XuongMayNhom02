using System.Threading.Tasks;
using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly MyDbContext _context;

        public TaskRepository(MyDbContext context) {
            _context = context;
        }
        public List<TaskModel> GetAll()
        {
            var list = _context.Tasks.Select(c => new TaskModel
            {
                TaskId = c.TaskId,
                TaskName = c.TaskName,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Quantity = c.Quantity,
                ProductionLineId = c.ProductionLineId,
                OrderId = c.OrderId

            });
            return list.ToList();
        }

        public TaskModel GetById(int id)
        {
            var task = _context.Tasks.SingleOrDefault(c => c.TaskId == id);
            if (task != null)
                return new TaskModel
                {
                    TaskId = task.TaskId,
                    TaskName = task.TaskName,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    Quantity = task.Quantity,
                    ProductionLineId = task.ProductionLineId,
                    OrderId = task.OrderId
                };
            return null;
        }

        public void insert(TaskModel temp)
        {
            var addNew = new Data.Task
            {
                TaskId = temp.TaskId,
                TaskName = temp.TaskName,
                StartDate = temp.StartDate,
                EndDate = temp.EndDate,
                Quantity = temp.Quantity,
                ProductionLineId = temp.ProductionLineId,
                OrderId = temp.OrderId
            };
            _context.Tasks.Add(addNew);
            _context.SaveChanges();
        }

        public int update(TaskModel temp)
        {
            var edit = _context.Tasks.SingleOrDefault(c => c.TaskId == temp.TaskId);
            if (edit != null)
            {
                edit.TaskName = temp.TaskName;
                edit.StartDate = temp.StartDate;
                edit.EndDate = temp.EndDate;
                edit.Quantity = temp.Quantity;
                edit.ProductionLineId = temp.ProductionLineId;
                edit.OrderId = temp.OrderId;
                _context.SaveChanges();
                return 1;
            }
            return 0;

        }
        public int delete(int id)
        {
            var del = _context.Tasks.SingleOrDefault(c => c.TaskId == id);
            if (del != null)
            {
                _context.Tasks.Remove(del);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}

