using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMay_Nhom2.Models;
using XuongMay_Nhom2.Repositories;

namespace XuongMay_Nhom2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }
        
        [HttpGet]
        [Authorize(Roles = "Quản lý")]
        public ActionResult GetAll(int page)
        {
            try
            {
                var ds = _employeeRepository.GetAll();
                ds = ds.Skip((page - 1) * 5).Take(5).ToList();
                return Ok(ds);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Quản lý")]
        public ActionResult GetById(int id)
        {
            var cate = _employeeRepository.GetById(id);
            if (cate != null)
                return Ok(cate);
            else return BadRequest("không tìm thấy Employee");
        }
        [HttpPost]
        [Authorize(Roles = "Quản lý")]
        public ActionResult Insert(EmployeeModel addNew)
        {
            try
            {
                _employeeRepository.insert(addNew);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize(Roles = "Quản lý")]
        public ActionResult Update(EmployeeModel edit)
        {
            try
            {
                int kq = _employeeRepository.update(edit);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Employee cần update");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Quản lý")]
        public ActionResult Delete(int id)
        {
            try
            {
                int kq = _employeeRepository.delete(id);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Employee cần delete");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
