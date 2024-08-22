using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDbContext _context;

        public EmployeeRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<EmployeeModel> GetAll()
        {
            var list = _context.Employees.Select(c => new EmployeeModel
            {
                EmployeeId = c.EmployeeId,
                EmployeeName = c.EmployeeName,
                Address = c.Address,
                Email = c.Email,
                Gender = c.Gender,
                PhoneNumber = c.PhoneNumber,
                RoleId = c.RoleId
            });
            return list.ToList();
        }

        public EmployeeModel GetById(int id)
        {
            var kq = _context.Employees.SingleOrDefault(c => c.EmployeeId == id);
            if ( kq!= null)
                return new EmployeeModel
                {
                    EmployeeId =  kq.EmployeeId,
                    EmployeeName = kq.EmployeeName,
                    Address = kq.Address,
                    Email = kq.Email,
                    Gender = kq.Gender,
                    PhoneNumber = kq.PhoneNumber,
                    RoleId = kq.RoleId
                };
            return null;
        }

        public void insert(EmployeeModel temp)
        {
            var addNew = new Employee
            {
                EmployeeId = temp.EmployeeId,
                EmployeeName = temp.EmployeeName,
                Address = temp.Address,
                Email = temp.Email,
                Gender = temp.Gender,

                PhoneNumber = temp.PhoneNumber,
                RoleId = temp.RoleId


            };
            _context.Employees.Add(addNew);
            _context.SaveChanges();
        }

        public int update(EmployeeModel temp)
        {
            var edit = _context.Employees.SingleOrDefault(c => c.EmployeeId== temp.EmployeeId);
            if (edit != null)
            {
                edit.EmployeeName = temp.EmployeeName;
                edit.Address = temp.Address;
                edit.Email = temp.Email;
                edit.Gender = temp.Gender;
                edit.PhoneNumber = temp.PhoneNumber;
                edit.RoleId = temp.RoleId;
                _context.SaveChanges();
                return 1;
            }
            return 0;

        }
        public int delete(int id)
        {
            var del = _context.Employees.SingleOrDefault(c => c.EmployeeId == id);
            if (del != null)
            {
                _context.Employees.Remove(del);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
