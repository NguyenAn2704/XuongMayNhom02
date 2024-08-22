using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMay_Nhom2.Models;
using XuongMay_Nhom2.Repositories;

namespace XuongMay_Nhom2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        [Authorize(Roles = "Chuyền trưởng, Quản lý")]
        public ActionResult GetAll(int page)
        {
            try
            {
                var ds = _taskRepository.GetAll();
                ds = ds.Skip((page - 1) * 5).Take(5).ToList();
                return Ok(ds);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Chuyền trưởng, Quản lý")]
        public ActionResult GetById(int id)
        {
            var cate = _taskRepository.GetById(id);
            if (cate != null)
                return Ok(cate);
            else return BadRequest("không tìm thấy Task");
        }
        [HttpPost]
        [Authorize(Roles = "Chuyền trưởng")]
        public ActionResult Insert(TaskModel addNew)
        {
            try
            {
                _taskRepository.insert(addNew);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize(Roles = "Chuyền trưởng")]
        public ActionResult Update(TaskModel edit)
        {
            try
            {
                int kq = _taskRepository.update(edit);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Task cần update");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Chuyền trưởng")]
        public ActionResult Delete(int id)
        {
            try
            {
                int kq = _taskRepository.delete(id);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Task cần delete");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
