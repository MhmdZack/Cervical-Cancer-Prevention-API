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
    public class GetGynaCenterByCodeValidaator : AbstractValidator<GetGynaCenterByCode>
    {
        private readonly IGynaecologyCenterRepositoryAsync _gynaRepository;

        public GetGynaCenterByCodeValidaator(IGynaecologyCenterRepositoryAsync gynaRepository)
        {
            _gynaRepository = gynaRepository;

            RuleFor(p => p.GynCenterCode)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MustAsync(IsGynaCenterCodeExists).WithMessage("{PropertyName} not exists.");

            RuleFor(p => p.ClientId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MustAsync(IsClientIdExists).WithMessage("{PropertyName} not exists.");
        }

        private async Task<bool> IsGynaCenterCodeExists(string gynaCenterCode, CancellationToken arg2)
        {
            var o = (await _gynaRepository.FindByCondition(x => x.GynCenterCode.Equals(gynaCenterCode)).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            if (o != null)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> IsClientIdExists(long clientId, CancellationToken arg2)
        {
            var o = (await _gynaRepository.FindByCondition(x => x.ClientId == clientId).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            if (o != null)
            {
                return true;
            }
            return false;
        }
    }
}
