using CommonData.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;


namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IBus bus;
        Uri uri = new Uri("rabbitmq:localhost/fromUserQueue");
        CustomerDBContext db = new CustomerDBContext();
        //CustomerServiceContext db = new CustomerServiceContext();
        private IConfiguration _config;

      
        public LoginController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        [Route("get-user")]
        public IEnumerable<TblUser> Get()
        {
            return db.TblUsers;
        }

        [HttpPost]
        [Route("login-user")]
        public async Task<IActionResult> LoginAsync(TblUser login)
        {
            bool IsRegister = false; //modified
            bool IsUpdate = false;
            if (login.Name != null)
                IsRegister = true;
            if(db.TblUsers.Any(x => x.EmailAddress == login.EmailAddress))
            {
                IsUpdate = true;
            }

            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login, IsRegister,IsUpdate);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;

            Uri uri = new Uri("rabbitmq:localhost/fromUserQueue");
            var endpoint = await bus.GetSendEndpoint(uri);
            await endpoint.Send(response);
           
        }



        private TblUser AuthenticateUser(TblUser login, bool IsRegister, bool IsUpdate)
        {

            if (IsRegister)
            {
                var email = db.TblUsers.Where(x => x.EmailAddress == login.EmailAddress).Count();
                var search = db.TblUsers.Where(x => x.EmailAddress == login.EmailAddress).FirstOrDefault();

                if (email ==1)
                {
                    var data = db.TblUsers.Where(x => x.Id == search.Id).FirstOrDefault();
                    data.Id = search.Id;
                    data.Name = login.Name;
                    data.Address = login.Address;
                    data.Address = login.Address;
                    data.State = login.State;
                    data.Country = login.Country;
                    data.EmailAddress = login.EmailAddress;
                    data.Password = login.Password;
                    data.Pan = login.Pan;
                    data.ContactNo = login.ContactNo;
                    data.Dob = login.Dob;
                    data.ContactPreference = login.ContactPreference;


                    db.TblUsers.Update(data);
                    db.SaveChanges();
                    return data;
                }
                    else
                        {

                    db.TblUsers.Add(login);
                    db.SaveChanges();
                    return login;
                }
              
            }
           
            
            else
            {
                if (db.TblUsers.Any(x => x.EmailAddress == login.EmailAddress && x.Password == login.Password))
                {
                    return db.TblUsers.Where(x => x.EmailAddress == login.EmailAddress && x.Password == login.Password).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }


        }

       

        private string GenerateToken(TblUser login)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["jwt:Issuer"],
                _config["jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


