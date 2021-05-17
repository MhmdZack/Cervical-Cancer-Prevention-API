using FluentValidation;
using NexGenScreening.Application.Interfaces.Repositories;

namespace NexGenScreening.Application.Features.Sample.Commands
{
    public class CreateMyTestCommandValidator : AbstractValidator<CreateMyTestCommand>
    {
        private readonly IMyTestRepositoryAsync myTestRepository;

        public CreateMyTestCommandValidator(IMyTestRepositoryAsync myTestRepository)
        {
            this.myTestRepository = myTestRepository;

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
