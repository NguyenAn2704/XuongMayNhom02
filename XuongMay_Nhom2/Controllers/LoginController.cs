using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XuongMay_Nhom2.Data;
using XuongMay_Nhom2.Models;

namespace XuongMay_Nhom2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;
        public LoginController(MyDbContext context,IConfiguration configuration) {
            _context = context;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
                return BadRequest("Xác nhận mật khẩu khôn giống nhau");
            var checkID = _context.Employees.FirstOrDefault(x=>x.EmployeeId == model.EmployeeId);
            var checkUserName = _context.Employees.FirstOrDefault(x=>x.UserName == model.UserName);
            if (checkID == null) return BadRequest("Không tìm thấy EmployeeId!");
            if (checkUserName != null) return BadRequest("UserName này đã tồn tại!");
            checkID.UserName = model.UserName;
            checkID.Password = model.Password;
            _context.SaveChanges();
            return Ok("Register thành công");

        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModel model)
        {
            var user = _context.Employees.Include(e => e.Role).FirstOrDefault(e=>e.UserName == model.UserName && e.Password==model.Password);
            if (user != null) {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role.RoleName),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                var SignIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(1),
                    signingCredentials : SignIn   
                    );
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));    
            }
            return BadRequest("UserName hoặc Password không đúng!");
        } 
    }
}
