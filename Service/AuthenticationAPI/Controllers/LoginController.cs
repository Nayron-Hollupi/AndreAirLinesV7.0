using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ServiceAplication.ServiceUser;

namespace AuthenticationAPI.Controllers
{
   
    [ApiController]
    [Route("V1")]
    public class LoginController : ControllerBase
    {

            [HttpPost]
            [Route("login")]
            [AllowAnonymous]
            public async Task<ActionResult<dynamic>> Authenticate(Login model)
            {


            var user = await ServiceSeachUser.SeachUserAuth(model.UserName); 

            if (user != null)
            {
                if (user.Login == model.UserName && user.Password == model.Password)
                {
                    var token = ServiceToken.GenerateToken(user);

                    user.Password = "";

                    return new
                    {                      
                        token = token
                    };
                }
                else
                {
                    return NotFound(new { message = "User or password invalidade!!" });
                }

            }
            else
            {
                return NotFound(new { message = "User does not exist !!" });
            }


        }


     

    }
    }

