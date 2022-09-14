using CoreProject.IRepository;
using CoreProject.ServiceDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _IRepository;

        public StudentController(IStudentRepository IRepository)
        {
            _IRepository = IRepository;
        }

        [HttpGet]
        [Route("GetStudentById")]
        public async Task<IActionResult> GetStudentById(long StudentId)
        {
            try
            {
                var data = await _IRepository.GetStudentById(StudentId);
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(JsonConvert.SerializeObject(data));

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentDTO obj)
        {
            try
            {
                var rspn = await _IRepository.AddStudent(obj);

                if (rspn == null)
                {
                    return NotFound();
                }

                return Ok(JsonConvert.SerializeObject(rspn));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("EditStudent")]
        public async Task<IActionResult> EditStudent(StudentDTO obj)
        {
            try
            {
                var data = await _IRepository.EditStudent(obj);

                if (data == null)
                {
                    return NotFound();
                }
                return Ok(JsonConvert.SerializeObject(data));
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
