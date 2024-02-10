using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using vpsAPI.IRepositories;
using vpsAPI.DTOs;
using vpsAPI.DTOs.DTOsVM;
using vpsAPI.Models;
using FluentValidation;
using vpsAPI.Validator;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vpsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGroupsRepository groupsRepository;
        private readonly IValidator<CreateGroupDto> createValidator;
        private readonly IValidator<EditGroupDto> editValidator;
        private readonly IValidator<GroupsDto> deleteValidator;

        public GroupsController(IMapper mapper,IGroupsRepository groupsRepository,
            IValidator<CreateGroupDto> createValidator,
            IValidator<EditGroupDto> editValidator,
            IValidator<GroupsDto> deleteValidator)
        {
            this.mapper = mapper;
            this.groupsRepository = groupsRepository;
            this.createValidator = createValidator;
            this.editValidator = editValidator;
            this.deleteValidator = deleteValidator;
        }
        [Route("Create")]
        [HttpPost]
        public  async Task<IActionResult> Create(CreateGroupDto groupDto)
        {
            var validationContext =  await createValidator.ValidateAsync(groupDto);
            if (!validationContext.IsValid)
            {
                return BadRequest(validationContext.Errors.Any());
            }
            else
            {
                var groupData = mapper.Map<Groups>(groupDto);
                groupData.CreatedDate = DateTime.Now;
                groupData.CreatedBy = "1";
                var result=groupsRepository.Create(groupData);
                return Ok(mapper.Map<GroupsDto>(result));
            }
        }
        [Route("Edit")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id,EditGroup group)
        {
            EditGroupDto dto = new EditGroupDto();
            dto.GroupId = id;
            dto.GroupName = group.GroupName;
            dto.GroupDescription = group.GroupDescription;
            dto.DepartmentId = group.DepartmentId;
            var validationContext = await editValidator.ValidateAsync(dto);
            if (!validationContext.IsValid)
            {
                return BadRequest(validationContext.Errors);
            }
            else
            {
                var groupNewData = mapper.Map<Groups>(dto);
                var result = await groupsRepository.Edit(groupNewData);
                return Ok(mapper.Map<GroupsDto>(result));
            }
        }
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            GroupsDto obj = new GroupsDto();
            obj.GroupId = Id;
            var validationContext = await deleteValidator.ValidateAsync(obj);
            if (!validationContext.IsValid)
            {
                return BadRequest(validationContext.Errors);
            }
            else
            {
                var result = groupsRepository.Delete(Id);
                return Ok(new { message = "Group was deleted successfully" });
            }

        }
        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var group =  await groupsRepository.GetById(Id);
            var groupDto = mapper.Map<GroupsVMDto>(group);
            if (groupDto != null)
            {
                return Ok(groupDto);
            }
            else
            {
                return NotFound(new ErrorResponseModel("Group of this Id was not found!"));
            }


        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetByAll()
        {
            var groupslst = groupsRepository.GetAll();
            var groupslstDto = mapper.Map<IEnumerable<GroupsVMDto>>(groupslst);
            if (groupslstDto != null)
            {
                return Ok(groupslstDto);
            }
            else
            {
                return NotFound(new ErrorResponseModel("No Groups Found!"));
            }

        }
    }
}
