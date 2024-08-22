using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;
using XuongMay_Nhom2.Repositories;

namespace XuongMay_Nhom2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public ActionResult GetAll(int page)
        {
            try
            {
                var ds = _categoryRepository.GetAll();
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
            var cate = _categoryRepository.GetById(id);
            if(cate != null) 
                return Ok(cate);
            else return BadRequest("không tìm thấy Category");
        }
        [HttpPost]
        [Authorize(Roles = "Nhân viên")]
        public ActionResult Insert(CategoryModel addNew)
        {
            try
            {
                _categoryRepository.insert(addNew);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize(Roles = "Nhân viên")]
        public ActionResult Update(CategoryModel edit)
        {
            try
            {
                int kq = _categoryRepository.update(edit);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Catogory cần update");
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
                int kq = _categoryRepository.delete(id);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Catogory cần delete");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
