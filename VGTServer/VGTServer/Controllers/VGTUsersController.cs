using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VGTDataStore.Core;
using System.Security.Cryptography;
using VGTServer.Answers;
using VGTServer.Models;

namespace VGTServer.Controllers
{
    [Route("/api/users/")]
    [ApiController]
    public class VGTUsersController : ControllerBase
    {
        private IVGTUserDataStore _usersDataStore;

        public VGTUsersController(IVGTUserDataStore userDataStore)
        {
            _usersDataStore = userDataStore;
        }

        [HttpGet]
        public IActionResult GetVGTUsers()
        {
            if (_usersDataStore.Users != null)
                return Ok(_usersDataStore);

            return NotFound();
        }

        [HttpGet("auth/Login={login}&Password={password}")]
        public IActionResult GetVGTUser(string login, string password)
        {
            foreach (var user in _usersDataStore.Users.Values)
            {
                if (login == user.Login
                    && password == user.Password)
                    return Ok(new Answer(user.UserId, "OK"));
            }

            return BadRequest(new Answer(Guid.Empty, "Wrong data"));
        }

        [HttpPost("register")]
        public IActionResult RegisterVGTUser([FromBody] VGTUserCreateModel user)
        {
            if (user == null)
                return BadRequest(new Answer(Guid.Empty, "Wrong userdata"));

            foreach (var storedUser in _usersDataStore.Users.Values)
            {
                if (storedUser.Login == user.Login)
                    return BadRequest(new Answer(Guid.Empty, "User with that login already exists"));

                if (storedUser.Email == user.Email)
                    return BadRequest(new Answer(Guid.Empty, "User with that email already exists"));
            }

            var restrictedUser = user.ToVGTUser();
            Guid id = _usersDataStore.AddUser(restrictedUser);

            return Ok(new Answer(id, "Added successfully"));
        }
    }
}
