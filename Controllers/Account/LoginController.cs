using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sisu_olorin_api.Data;
using sisu_olorin_api.Models.Access;
using sisu_olorin_api.Models.Profile;
using sisu_olorin_api.Tools;

namespace sisu_olorin_api.Controllers.Account
{
    [Route("Account/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostLogin(FormLogin formLogin)
        {
            Login getUser = await _context.Logins.Where(b => b.Password == Password.hashPassword(formLogin.Password) && b.User.Email == formLogin.Email).FirstAsync();

            if (getUser == null)
            {
                return BadRequest("Usuário ou senha não encontrados!");
            }

            User user = _context.Users.FindAsync(getUser.UserId).Result;

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }

    public class FormLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
