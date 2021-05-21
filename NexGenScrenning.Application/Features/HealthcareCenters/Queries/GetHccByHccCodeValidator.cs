using FluentValidation;
using NexGenScreening.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.Queries
{
    public class GetHccByHccCodeValidator : AbstractValidator<GetHccByHccCode>
    {
        private readonly IHealthcareCenterRepositoryAsync _healthcareCenterRepository;

        public GetHccByHccCodeValidator(IHealthcareCenterRepositoryAsync healthcareCenterRepository)
        {
            _healthcareCenterRepository = healthcareCenterRepository;

            RuleFor(p => p.HccCode)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MustAsync(IsHccCodeExists).WithMessage("{PropertyName} not exists.");

            RuleFor(p => p.ClientId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MustAsync(IsClientIdExists).WithMessage("{PropertyName} not exists.");
        }

        private async Task<bool> IsClientIdExists(long clientId, CancellationToken cancellationToken)
        {
            var userObject = (await _healthcareCenterRepository.FindByCondition(x => x.ClientId == clientId).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            if (userObject != null)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> IsHccCodeExists(string hccCode, CancellationToken cancellationToken)
        {
            var userObject = (await _healthcareCenterRepository.FindByCondition(x => x.HccCode.Equals(hccCode)).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            if (userObject != null)
            {
                return true;
            }
            return false;
        }
    }
}
