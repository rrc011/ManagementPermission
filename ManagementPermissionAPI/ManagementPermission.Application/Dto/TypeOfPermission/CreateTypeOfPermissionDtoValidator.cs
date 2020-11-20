using FluentValidation;

namespace ManagementPermission.Application.Dto.TypeOfPermission
{
    public class CreateTypeOfPermissionDtoValidator : AbstractValidator<CreateTypeOfPermissionDto>
    {
        public CreateTypeOfPermissionDtoValidator()
        {
            RuleFor(m => m.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
