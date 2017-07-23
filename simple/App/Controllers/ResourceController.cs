using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Simple.Models;
using Simple.DAL;

namespace Simple.Controllers
{
    [Route("api/resource")]
    public class ResourceController : Controller
    {
        private IRepository<User> _repo;

        public ResourceController(IRepository<User> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException(nameof(repo));
            }

            _repo = repo;    
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string username)
        {
            User user = await _repo.GetAsync(x => x.Username == username);
 
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var result = await _repo.AddAsync(user);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            if (user == null || user.Id == null)
            {
                return BadRequest();
            }

            var result = await _repo.UpdateAsync(user.Id, user);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await _repo.DeleteAsync(id);
            return Ok();
        }
    }
}