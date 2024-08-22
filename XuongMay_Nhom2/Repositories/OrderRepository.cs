using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly MyDbContext _context;

        public OrderRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<OrderModel> GetAll()
        {
            var list = _context.Orders.Select(c => new OrderModel
            {
                OrderId = c.OrderId,
                OrderDate = c.OrderDate,
                DeliveryDeadline = c.DeliveryDeadline,
                Status = c.Status,
                ProductId = c.ProductId,
                Quantity = c.Quantity,
                Unitprice = c.Unitprice,
                TotalAmount = c.TotalAmount
               
            });
            return list.ToList();
        }

        public OrderModel GetById(int id)
        {
            var kq = _context.Orders.SingleOrDefault(c => c.OrderId == id);
            if (kq != null)
                return new OrderModel
                {
                    OrderId = kq.OrderId,
                    OrderDate = kq.OrderDate,
                    DeliveryDeadline = kq.DeliveryDeadline,
                    Status = kq.Status,
                    ProductId = kq.ProductId,
                    Quantity = kq.Quantity,
                    Unitprice = kq.Unitprice,
                    TotalAmount = kq.TotalAmount


                };
            return null;
        }

        public void insert(OrderModel temp)
        {
            var addNew = new Order
            {
                OrderId = temp.OrderId,
                OrderDate = temp.OrderDate,
                DeliveryDeadline = temp.DeliveryDeadline,
                Status = temp.Status,
                ProductId = temp.ProductId,
                Quantity = temp.Quantity,
                Unitprice = temp.Unitprice,
                TotalAmount = temp.TotalAmount

            };
            _context.Orders.Add(addNew);
            _context.SaveChanges();
        }

        public int update(OrderModel temp)
        {
            var edit = _context.Orders.SingleOrDefault(c => c.OrderId== temp.OrderId);
            if (edit != null)
            {
                edit.OrderDate = temp.OrderDate;
                edit.DeliveryDeadline = temp.DeliveryDeadline;
                edit.Status = temp.Status;
                edit.ProductId = temp.ProductId;
                edit.Quantity = temp.Quantity;
                edit.Unitprice = temp.Unitprice;
                edit.TotalAmount = temp.TotalAmount;
                _context.SaveChanges();
                return 1;
            }
            return 0;

        }
        public int delete(int id)
        {
            var del = _context.Orders.SingleOrDefault(c => c.OrderId == id);
            if (del != null)
            {
                _context.Orders.Remove(del);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
