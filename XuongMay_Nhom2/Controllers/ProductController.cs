using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMay_Nhom2.Models;
using XuongMay_Nhom2.Repositories;

namespace XuongMay_Nhom2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult GetAll(int page)
        {
            try
            {
                var ds = _productRepository.GetAll();
                ds = ds.Skip((page-1)*5).Take(5).ToList();
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
            var cate = _productRepository.GetById(id);
            if (cate != null)
                return Ok(cate);
            else return BadRequest("không tìm thấy Product");
        }
        [HttpPost]
        [Authorize(Roles = "Nhân viên")]
        public ActionResult Insert(ProductModel addNew)
        {
            try
            {
                _productRepository.insert(addNew);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize(Roles = "Nhân viên")]
        public ActionResult Update(ProductModel edit)
        {
            try
            {
                int kq = _productRepository.update(edit);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Product cần update");
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
                int kq = _productRepository.delete(id);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Product cần delete");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
