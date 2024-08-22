using Microsoft.EntityFrameworkCore;
using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public class ProductionLineRepository:IProductionLineRepository
    {
        private readonly MyDbContext _context;

        public ProductionLineRepository(MyDbContext context) {
            _context = context;
        }

        public List<ProductionLineModel> GetAll()
        {
            var list = _context.ProductionLines.Select(c => new ProductionLineModel
            {
                ProductionLineId = c.ProductionLineId,
                ProductionLineName = c.ProductionLineName,
                EmployeeId = c.EmployeeId,
                NumOfEmployees = c.NumOfEmployees
                
            });
            return list.ToList();
        }

        public ProductionLineModel GetById(int id)
        {
            var ProductionLine = _context.ProductionLines.SingleOrDefault(c => c.ProductionLineId == id);
            if (ProductionLine != null)
                return new ProductionLineModel
                {
                    ProductionLineId= ProductionLine.ProductionLineId,
                    ProductionLineName= ProductionLine.ProductionLineName,
                    EmployeeId= ProductionLine.EmployeeId,
                    NumOfEmployees = ProductionLine.NumOfEmployees

                };
            return null;
        }

        public void insert(ProductionLineModel temp)
        {
            var addNew = new ProductionLine
            {
                ProductionLineId = temp.ProductionLineId,
                NumOfEmployees= temp.NumOfEmployees,
                EmployeeId = temp.EmployeeId,
                ProductionLineName= temp.ProductionLineName
            };
            _context.ProductionLines.Add(addNew);
            _context.SaveChanges();
        }

        public int update(ProductionLineModel temp)
        {
            var edit = _context.ProductionLines.SingleOrDefault(c => c.ProductionLineId == temp.ProductionLineId);
            if (edit != null)
            {
                edit.NumOfEmployees = temp.NumOfEmployees;
                edit.EmployeeId = temp.EmployeeId;
                edit.ProductionLineName = temp.ProductionLineName;

                _context.SaveChanges();
                return 1;
            }
            return 0;

        }
        public int delete(int id)
        {
            var del = _context.ProductionLines.SingleOrDefault(c => c.ProductionLineId == id);
            if (del != null)
            {
                _context.ProductionLines.Remove(del);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
