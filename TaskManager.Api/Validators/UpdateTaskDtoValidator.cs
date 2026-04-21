using FluentValidation;
using TaskManager.Api.DTOs;

namespace TaskManager.Api.Validators
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskDto>
    {
        public UpdateTaskDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título é obrigatório.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("O status é obrigatório.")
                .Must(s => new[] { "Todo", "Doing", "Done" }.Contains(s))
                .WithMessage("Status inválido. Os valores válidos são: Todo, Doing e Done.");
        }
    }
}
