using System.Collections.Generic;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;
using LogRabbitService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceAplication.ServiceUser;
using UserAPI.Service;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
            private readonly UserService _userService;


            public UserController(UserService userService)
            {
                _userService = userService;
            }

            [HttpGet]
            //[Authorize(Roles = "employee,manager")]
            public ActionResult<List<User>> Get() =>
                _userService.Get();


            [HttpGet("{id:length(24)}", Name = "GetUser")]
           // [Authorize(Roles = "employee,manager")]
            public ActionResult<User> Get(string id)
            {
                var user = _userService.Get(id);

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }

        [HttpGet("{Login}", Name = "GetLogin")]
        [AllowAnonymous]
        public ActionResult<User> GetSeachLogin(string Login)
        {
            var user = _userService.GetLogin(Login);

            if (user == null)
                return NotFound("User no Exist");

            return user;
        }

       
        [HttpPost]
          [Authorize(Roles = "employee,manager")]
            public async Task<ActionResult<User>> Create(User user)
            {
                var cpf = _userService.ExistCPF(user.CPF);
                var check = _userService.CheckCpf(user.CPF);


                if (check == true)
                {
                    if (cpf == null)
                    {

                        var address = await ServiceViaCep.CorreioApi(user.Address.CEP);
                        if (address != null)
                        {
                            user.Address = address;
                        }
                    var userJson = JsonConvert.SerializeObject(user);
                    var lograbbit = new Log(user.LoginUser, null, userJson, "Create");

                    SenderMongoServerService.LoginRabbit(lograbbit);

                    _userService.Create(user);
                    }
                    else
                    {
                        return Conflict("CPF já esta cadastrado");
                    }
                }
                else
                {
                    return Conflict("CPF invalido");
                }


                return CreatedAtRoute("GetUser", new { Id = user.Id.ToString() }, user);
            }

            [HttpPut("{id:length(24)}")]
            [Authorize(Roles = "employee,manager")]
            public IActionResult Update(string id, User userIn)
            {
                var user = _userService.Get(id);

                if (user == null)
                {
                    return NotFound();
                }

            var olduser = JsonConvert.SerializeObject(user);
            var userJson = JsonConvert.SerializeObject(userIn);
            var lograbbit = new Log(user.LoginUser, olduser, userJson, "Update");

            SenderMongoServerService.LoginRabbit(lograbbit);
            _userService.Update(id, userIn);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            [Authorize(Roles = "manager")]
            public IActionResult Delete(string id)
            {
                var user = _userService.Get(id);

                if (user == null)
                {
                    return NotFound();
                }


            var userJson = JsonConvert.SerializeObject(user);
            var lograbbit = new Log(user.LoginUser, null, userJson, "Delete");

            SenderMongoServerService.LoginRabbit(lograbbit);

            _userService.Remove(user.Id);

                return NoContent();
            }
        }
}
