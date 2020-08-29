using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VGTSERVER1.Controllers
{
    [Route("api/Auth")]
    public class ValuesController : Controller
    {
        // GET api/values


        // GET api/values/5
        [HttpGet("register/Login={login}&Password={Password}")]
        public string Get(string login,string Password)
        {
            User userreg = new User();
            UserInterface user = new UserInterface(login, Password);
            user.Get(login);
            return user.Get(login).Password;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
