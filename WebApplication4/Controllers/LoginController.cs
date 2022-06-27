using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using DTO;

namespace WebApplication4.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
       

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
        [Route("GetEmailAddressPassword/{e_mail}/{password}")]
        [HttpGet]
        public Volunteer GetEmailAddressPassword(string e_mail, string password)
        {
            return LoginBL.GetEmailAddressPassword(e_mail, password);
        }
        [Route("GetEmailAddressPassword1/{e_mail}/{password}")]
        [HttpGet]
        public Assisted GetEmailAddressPassword1(string e_mail, string password)
        {
            return LoginBL.GetEmailAddressPassword1(e_mail, password);
        }
    }
}
