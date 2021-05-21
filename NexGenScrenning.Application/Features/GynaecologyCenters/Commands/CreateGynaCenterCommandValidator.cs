using FluentValidation;
using NexGenScreening.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.Commands
{
    public class CreateGynaCenterCommandValidator : AbstractValidator<CreateGynaCenterCommand>
    {
        private readonly IGynaecologyCenterRepositoryAsync gynaCenterRepository;

        public CreateGynaCenterCommandValidator(IGynaecologyCenterRepositoryAsync gynaCenterRepository)
        {
            this.gynaCenterRepository = gynaCenterRepository;

            RuleFor(p => p.GynCenterCode)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.")
                .MustAsync(IsUniqueGynaCode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.GyncCenterName)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
                .MustAsync(IsUniqueGynaName).WithMessage("{PropertyName} already exists.");

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

            RuleFor(p => p.CreatedBy)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull();

            RuleFor(p => p.ClientId)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull();
        }

        private async Task<bool> IsUniqueGynaName(string gynaName, CancellationToken arg2)
        {
            var GynaObject = (await gynaCenterRepository
                .FindByCondition(x => x.GyncCenterName.ToLower() == gynaName.ToLower())
                .ConfigureAwait(false))
                .AsQueryable().FirstOrDefault();
            
            if (GynaObject != null)
                return false;
            
            return true;
        }

        private async Task<bool> IsUniqueGynaCode(string gynaCode, CancellationToken arg2)
        {
            var GynaObject = (await gynaCenterRepository
                .FindByCondition(x => x.GynCenterCode.ToLower() == gynaCode.ToLower())
                .ConfigureAwait(false))
                .AsQueryable()
                .FirstOrDefault();
            
            if (GynaObject != null)
                return false;
            
            return true;
        }
    }
}
