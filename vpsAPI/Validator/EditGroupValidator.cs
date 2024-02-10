using FluentValidation;
using vpsAPI.DTOs.DTOsVM;
using vpsAPI.IRepositories;
using vpsAPI.Services;

namespace vpsAPI.Validator
{
    public class EditGroupValidator:AbstractValidator<EditGroupDto>
    {
        private readonly IGroupsRepository gRepo;
        private readonly VPSContext _dbContext;
        public EditGroupValidator(IGroupsRepository gRepo, VPSContext _dbContext)
        {
            this.gRepo = gRepo;
            this._dbContext=_dbContext;
            RuleFor(g => g.GroupName)
               .NotNull()
               .NotEmpty()
               .WithMessage("Please enter Group Name")
               .Length(1, 10)
               .WithMessage("Group Name should be between 1 to 10 characters");

            RuleFor(g => g.GroupDescription)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please enter Group Description")
                .Length(1, 250)
                .WithMessage("Group Description should be between 1 to 250 characters");

            RuleFor(g => g.DepartmentId)
                .NotNull()
                .NotEmpty()
                .CustomAsync(ValidateDepartmentId);

        }

        private async Task ValidateDepartmentId(int id, ValidationContext<EditGroupDto> con, CancellationToken token)
        {
            var group= _dbContext.Groups.Find(con.InstanceToValidate.GroupId);
            if(group.DepartmentId !=id)
            {
                con.AddFailure("Department can not be changed.");
            }
        }
    }
}
