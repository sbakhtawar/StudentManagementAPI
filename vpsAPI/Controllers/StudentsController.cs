using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using vpsAPI.DTOs;
using vpsAPI.DTOs.DTOsVM;
using vpsAPI.Models;
using vpsAPI.IRepositories;
using FluentValidation;

namespace vpsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IStudentRepository studentRepository;
        private readonly IValidator<CreateStudentDto> createValidator;
        private readonly IValidator<StudentDto> editValidator;
        private readonly IValidator<AssignGroupDto> assignValidator;
        public StudentsController(IStudentRepository _studentRepository, IMapper mapper,
            IValidator<CreateStudentDto> createValidator,
            IValidator<StudentDto> editValidator,
            IValidator<AssignGroupDto> assignValidator)
        {
            this.studentRepository=_studentRepository;
            this.mapper = mapper;
            this.createValidator = createValidator;
            this.editValidator = editValidator;
            this.assignValidator = assignValidator;

        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto studentDto)
        {
            var validationContext = await createValidator.ValidateAsync(studentDto);
            if(!validationContext.IsValid)
            {
                return BadRequest(validationContext.Errors);
            }
            else
            {
                var studentData = mapper.Map<Students>(studentDto);
                studentData.CreatedDate = DateTime.Now;
                studentData.CreatedBy = "1";
                var result = studentRepository.Create(studentData);
                return Ok(mapper.Map<StudentDto>(result));
            }
        }
        [Route("AssignGroup")]
        [HttpPost]
        public async Task<IActionResult> AssignGroup(AssignGroupDto assignDto)
        {
            var validationContext = await assignValidator.ValidateAsync(assignDto);
            if (!validationContext.IsValid)
            {
                return BadRequest(validationContext.Errors);

            }
            else
            {
                var student = await studentRepository.GetById(assignDto.StudentID);
                student.GroupId = assignDto.GroupId;
                var assignedGroup = await studentRepository.Edit(student);
                var studentData = mapper.Map<StudentDto>(assignedGroup);
                return Ok(studentData);
            }
 
        }

        [Route("Edit")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id,EditStudent student)
        { 
            StudentDto studentDto = new StudentDto();
            studentDto.StudentId=id;
            studentDto.StudentFirstName = student.StudentFirstName;
            studentDto.StudentLastName = student.StudentLastName;
            studentDto.GroupId = student.GroupId;
            studentDto.StudentAge = student.StudentAge;
            studentDto.AcademicPerformance = student.AcademicPerformance;

            var validationContext = await editValidator.ValidateAsync(studentDto);
            if (!validationContext.IsValid)
            {
                return BadRequest(validationContext.Errors);
            }
            else
            {
                var studentNewData = mapper.Map<Students>(studentDto);
                var result = await studentRepository.Edit(studentNewData);
                return Ok(mapper.Map<StudentDto>(result));
            }

        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            if (Id != 0)
            {
                var result = studentRepository.Delete(Id);
                if (result != null)
                {
                    return Ok(new { message = "Student was deleted successfully" });
                }
                else
                {
                    return BadRequest(new ErrorResponseModel("Missing Id"));

                }

            }
            return NotFound();

        }
        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var student = await studentRepository.GetById(Id);
            var studentDto = mapper.Map<StudentDto>(student);
            if (studentDto != null)
            {
                return Ok(studentDto);
            }
            else
            {
                return NotFound(new ErrorResponseModel("No Student Found!"));
            }


        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var studentlst = studentRepository.GetAll();
            var studentlstDto = mapper.Map<IEnumerable<StudentDto>>(studentlst);
            if (studentlstDto != null)
            {
                return Ok(studentlstDto);
            }
            else
            {
                return NotFound(new ErrorResponseModel("No Student List Found!"));
            }

        }
        [Route("GetByGroupId")]
        [HttpGet]
        public IActionResult GetByGroupId( int Id)
        {
            var studentlst = studentRepository.GetByGroupId(Id);
            var studentlstDto = mapper.Map<IEnumerable<StudentByGroupDto>>(studentlst);
            if (studentlstDto != null)
            {
                return Ok(studentlstDto);
            }
            else
            {
                return NotFound(new ErrorResponseModel("No Student of this ID Found!"));
            }

        }
        [Route("GetByDepartmentId")]
        [HttpGet]
        public IActionResult GetByDepartmentId(int Id)
        {
            var studentlst = studentRepository.GetByDepartmentId(Id);
            var studentlstDto = mapper.Map<IEnumerable<StudentByDeptDto>>(studentlst);
            if (studentlstDto != null)
            {
                return Ok(studentlstDto);
            }
            else
            {
                return NotFound(new ErrorResponseModel("No Students listed in this department"));
            }

        }
    }
}
