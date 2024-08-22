using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public class RoleRepository :  IRoleRepository
    {
        private readonly MyDbContext _context;

        public RoleRepository(MyDbContext context)
        {
            _context = context;
        }




        public List<RoleModel> GetAll()
        {
            var list = _context.Roles.Select(c => new RoleModel
            {
                RoleId = c.RoleId,
                RoleName = c.RoleName
            });
            return list.ToList();
        }

        public RoleModel GetById(int id)
        {
            var kq = _context.Roles.SingleOrDefault(c => c.RoleId == id);
            if ( kq!= null)
                return new RoleModel
                {
                    RoleId= kq.RoleId,
                    RoleName = kq.RoleName
                };
            return null;
        }

        public void insert(RoleModel temp)
        {
            var addNew = new Role
            {
                RoleId = temp.RoleId,
                RoleName = temp.RoleName
            };
            _context.Roles.Add(addNew);
            _context.SaveChanges();
        }

        public int update(RoleModel temp)
        {
            var edit = _context.Roles.SingleOrDefault(c => c.RoleId== temp.RoleId);
            if (edit != null)
            {
                edit.RoleName = temp.RoleName;
                _context.SaveChanges();
                return 1;
            }
            return 0;

        }
        public int delete(int id)
        {
            var del = _context.Roles.SingleOrDefault(c => c.RoleId == id);
            if (del != null)
            {
                _context.Roles.Remove(del);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
