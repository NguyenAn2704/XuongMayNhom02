using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMay_Nhom2.Models;
using XuongMay_Nhom2.Repositories;

namespace XuongMay_Nhom2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository) {
            _roleRepository = roleRepository;
        }
        [HttpGet]
        [Authorize(Roles = "Quản lý")]
        public ActionResult GetAll(int page)
        {
            try
            {
                var ds = _roleRepository.GetAll();
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
            var cate = _roleRepository.GetById(id);
            if (cate != null)
                return Ok(cate);
            else return BadRequest("không tìm thấy Role");
        }
        [HttpPost]
        [Authorize(Roles = "Quản lý")]
        public ActionResult Insert(RoleModel addNew)
        {
            try
            {
                _roleRepository.insert(addNew);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize(Roles = "Quản lý")]
        public ActionResult Update(RoleModel edit)
        {
            try
            {
                int kq = _roleRepository.update(edit);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Role cần update");
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
                int kq = _roleRepository.delete(id);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Role cần delete");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
