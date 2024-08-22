using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMay_Nhom2.Models;
using XuongMay_Nhom2.Repositories;

namespace XuongMay_Nhom2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository) {
            _orderRepository = orderRepository;
        }


        [HttpGet]

        public ActionResult GetAll(int page)
        {
            try
            {
                var ds = _orderRepository.GetAll();
                ds = ds.Skip((page - 1) * 5).Take(5).ToList();
                return Ok(ds);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var cate = _orderRepository.GetById(id);
            if (cate != null)
                return Ok(cate);
            else return BadRequest("không tìm thấy Order");
        }
        [HttpPost]
        [Authorize(Roles ="Nhân viên")]
        public ActionResult Insert(OrderModel addNew)
        {
            try
            {
                _orderRepository.insert(addNew);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize(Roles = "Nhân viên")]
        public ActionResult Update(OrderModel edit)
        {
            try
            {
                int kq = _orderRepository.update(edit);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Order cần update");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Nhân viên")]
        public ActionResult Delete(int id)
        {
            try
            {
                int kq = _orderRepository.delete(id);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Order cần delete");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
