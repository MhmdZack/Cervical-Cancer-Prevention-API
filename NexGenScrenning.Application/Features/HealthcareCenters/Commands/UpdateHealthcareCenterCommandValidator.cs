using FluentValidation;
using NexGenScreening.Application.Interfaces.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.Commands
{
    public class UpdateHealthcareCenterCommandValidator : AbstractValidator<UpdateHealthcareCenterCommand>
    {
        private readonly IHealthcareCenterRepositoryAsync hccRepository;

        public UpdateHealthcareCenterCommandValidator(IHealthcareCenterRepositoryAsync hccRepository)
        {
            this.hccRepository = hccRepository;

            RuleFor(p => p.HccCode)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 15 characters.");
                //.MustAsync(IsUniqueHccCode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.HccName)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 50 characters.");
                //.MustAsync(IsUniqueHccName).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.CAddressLine1)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CCity)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CPostalCode)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.TelePhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.UpdatedBy)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull();
        }

        private async Task<bool> IsUniqueHccName(string Name, CancellationToken cancellationToken)
        {
            var HccObject = (await hccRepository
                .FindByCondition(x => x.HccName.ToLower() == Name.ToLower())
                .ConfigureAwait(false))
                .AsQueryable()
                .FirstOrDefault();

            if (HccObject != null)
                return false;
            
            return true;
        }

        private async Task<bool> IsUniqueHccCode(string HccCode, CancellationToken cancellationToken)
        {
            var HccObject = (await hccRepository
                .FindByCondition(x => x.HccCode.ToLower() == HccCode.ToLower())
                .ConfigureAwait(false))
                .AsQueryable()
                .FirstOrDefault();

            if (HccObject != null)
                return false;

            return true;
        }
    }
}
