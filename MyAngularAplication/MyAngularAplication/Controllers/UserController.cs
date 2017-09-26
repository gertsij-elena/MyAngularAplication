using MyAngularAplication.Model;
using MyAngularAplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MyAngularAplication.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetAll());
        }

        // GET api/values/5
        [HttpGet]
        [Route("{id:int}", Name = "GetSingleUser")]
        public IActionResult GetSingleUser(int id)
        {
            User user = _userRepository.GetSingle(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Add([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User newUser = _userRepository.Add(user);

            return CreatedAtRoute("GetSingleUser", new { id = newUser.Id }, newUser);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody]User user)
        {
            User checkedUser = _userRepository.GetSingle(id);
            if (checkedUser == null)
            {
                return NotFound();
            }

            if (id != user.Id)
            {
                return BadRequest("Id do not match");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("ModelState is not valid");
            }
            User updateUser = _userRepository.Update(id, user);
            return Ok(updateUser);

        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            User user = _userRepository.GetSingle(id);
            if (user == null)
            {
                return NotFound();
            }
            _userRepository.Delete(id);
            return NoContent();

        }
    }
}
