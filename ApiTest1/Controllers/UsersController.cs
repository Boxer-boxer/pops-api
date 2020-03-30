using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest1.Models;
using ApiTest1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<Users>> Get() => 
            _userService.Get();

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<Users> Get(string id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<Users> Create(Users user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Users userIn)
        {
            var user = _userService.Get(id);

            if(user == null)
            {
                return NotFound();
            }
            _userService.Update(id, userIn);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if(user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }
    }
}
