using Exercise.Dto;
using Exercise.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartController : ControllerBase
    {
        private readonly IDepartmentsService _idepart;
        public DepartController(IDepartmentsService idepart)
        {
            _idepart = idepart;
        }

        [Authorize]
        [HttpPost ("AddDepart-Departmen")]
        public ActionResult<string> AddDepart(DepartmentDto department)
        {
            var depart = _idepart.AddNewDepartments(department);
            return Ok(depart);
        }
    }
}
