using FluentValidation;
using vpsAPI.DTOs;

namespace vpsAPI.Validator
{
    public class EditStudentValidator : AbstractValidator<StudentDto>
    {
        public EditStudentValidator()
        {
            RuleFor(g => g.StudentId)
              .NotNull()
              .NotEmpty()
              .WithMessage("Plese enter student id");

            RuleFor(stu => stu.StudentFirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please enter Student First Name")
                .Length(1, 10)
                .WithMessage("Student First Name should be between 1 to 10 characters");

            RuleFor(stu => stu.StudentLastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please enter Student Last Name")
                .Length(1, 10)
                .WithMessage("Student Last Name should be between 1 to 10 characters");

            RuleFor(stu => stu.AcademicPerformance)
                .InclusiveBetween(1, 5)
                .WithMessage("Academic Performance should be between 1 to 5");
        }
    }
}
