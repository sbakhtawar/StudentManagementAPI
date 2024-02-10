﻿using FluentValidation;
using vpsAPI.DTOs.DTOsVM;

namespace vpsAPI.Validator
{
    public class CreateGroupValidator:AbstractValidator<CreateGroupDto>
    {
        public CreateGroupValidator()
        {
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
                .WithMessage("A group must be assigned to a department");
        }
    }
}
