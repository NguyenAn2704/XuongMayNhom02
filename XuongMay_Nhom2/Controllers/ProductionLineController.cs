using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMay_Nhom2.Models;
using XuongMay_Nhom2.Repositories;

namespace XuongMay_Nhom2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionLineController : ControllerBase
    {
        private readonly IProductionLineRepository _productionLineRepository;

        public ProductionLineController(IProductionLineRepository productionLineRepository) {
            _productionLineRepository = productionLineRepository;
        }
        
        [HttpGet]
        [Authorize(Roles = "Quản lý")]
        public ActionResult GetAll(int page)
        {
            try
            {
                var ds = _productionLineRepository.GetAll();
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
            var cate = _productionLineRepository.GetById(id);
            if (cate != null)
                return Ok(cate);
            else return BadRequest("không tìm thấy ProductionLine");
        }
        [HttpPost]
        [Authorize(Roles = "Quản lý")]
        public ActionResult Insert(ProductionLineModel addNew)
        {
            try
            {
                _productionLineRepository.insert(addNew);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize(Roles = "Quản lý")]
        public ActionResult Update(ProductionLineModel edit)
        {
            try
            {
                int kq = _productionLineRepository.update(edit);
                if (kq == 0)
                    return BadRequest("Không tìm thấy ProductionLine cần update");
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
                int kq = _productionLineRepository.delete(id);
                if (kq == 0)
                    return BadRequest("Không tìm thấy Task ProductionLine delete");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
