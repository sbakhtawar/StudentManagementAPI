using FluentValidation;
using vpsAPI.DTOs;
using vpsAPI.IRepositories;

namespace vpsAPI.Validator
{
    public class DeleteGroupValidator: AbstractValidator<GroupsDto>
    {
        private readonly IStudentRepository stuRepo;

        public DeleteGroupValidator(IStudentRepository stuRepo)
        {
            this.stuRepo = stuRepo;
            RuleFor(x => x.GroupId).NotEmpty().CustomAsync(ValidateNoStudentInGroup);
        }

        private async Task ValidateNoStudentInGroup(int Id, ValidationContext<GroupsDto> context, CancellationToken arg3)
        {
            var students =  stuRepo.GetAll();
            if(students.Any(s=>s.GroupId== Id))
            {
                context.AddFailure("Can not delete this group because it has students");
            }
            
        }
    }
}
