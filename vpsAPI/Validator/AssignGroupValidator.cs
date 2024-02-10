using FluentValidation;
using vpsAPI.DTOs.DTOsVM;

namespace vpsAPI.Validator
{
    public class AssignGroupValidator:AbstractValidator<AssignGroupDto>
    {
        public AssignGroupValidator()
        {
            RuleFor(stu => stu.StudentID)
               .NotNull()
               .NotEmpty()
               .WithMessage("Please enter Student Id");

            RuleFor(stu => stu.GroupId)
               .NotNull()
               .NotEmpty()
               .WithMessage("Please enter group Id");
        }
    }
}
