using Exercise.Dto;
using Exercise.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpoyleeController : ControllerBase
    {
        private readonly IEmpoylee _empoylee;
        public EmpoyleeController(IEmpoylee empoylee)
        {
            _empoylee = empoylee;
        }

        [Authorize]
        [HttpPost("AddDepart-Empoylee")]
        public ActionResult<string> AddEmpolee(EmpoyleeDto empoylee, [FromQuery] int id)
        {
            var depart = _empoylee.AddEmpoylee(empoylee, id);
            return Ok(depart);
        }


        [Authorize]
        [HttpPut("Update-Empoylee")]
        public ActionResult<string> Update(EmpoyleeUpdateDto empoylee, [FromQuery] int derpart, int userId)
        {
            var depart = _empoylee.UpdatedEmpoylee(empoylee, derpart, userId);
            return Ok(depart);
        }


        [Authorize]
        [HttpDelete("delete-Empoylee")]
        public ActionResult<string> Delete(int userid)
        {
            var depart = _empoylee.Delete(userid);
            return Ok(depart);
        }
    }
}
