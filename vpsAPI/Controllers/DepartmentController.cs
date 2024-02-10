using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vpsAPI.IRepositories;
using AutoMapper;
using vpsAPI.DTOs;

namespace vpsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;
        public DepartmentController(IDepartmentRepository departmentRepository,IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;

        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var departmentlst = departmentRepository.GetAll();
            var departmentlstDto = mapper.Map<IEnumerable<DepartmentDto>>(departmentlst);
            if(departmentlstDto != null)
            {
                return Ok(departmentlstDto);
            }
            else
            {
                return NotFound(new ErrorResponseModel("No Department Found!"));
         
            }

        }
        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var department = await departmentRepository.GetById(Id);
            var departmentDto = mapper.Map<DepartmentDto>(department);
            if (departmentDto != null)
            {
                return Ok(departmentDto);
            }
            else
            {
                return NotFound(new ErrorResponseModel("Department of this Id does not exist!"));
            }

        }
    }
}
