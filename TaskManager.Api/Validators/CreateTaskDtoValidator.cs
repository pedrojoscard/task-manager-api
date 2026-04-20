using FluentValidation;
using TaskManager.Api.DTOs;

namespace TaskManager.Api.Validators
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MinimumLength(3).WithMessage("O título deve conter no mínimo 3 caracteres.")
                .MaximumLength(100).WithMessage("O título deve conter no máximo 100 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MinimumLength(5).WithMessage("A descrição deve ter no mínimo 5 caracteres.");
        }
    }
}
