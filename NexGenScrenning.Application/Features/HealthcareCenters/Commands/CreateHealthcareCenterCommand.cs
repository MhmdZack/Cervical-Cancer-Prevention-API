using AutoMapper;
using MediatR;
using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Application.Wrappers;
using NexGenScreening.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.HealthcareCenters.Commands
{
    public partial class CreateHealthcareCenterCommand : IRequest<Response<Guid>>
    {
        //public Int64 HccId { get; set; }
        public string HccCode { get; set; }
        public string HccName { get; set; }
        public string CAddressLine1 { get; set; }
        public string CAddressLine2 { get; set; }
        public string CAddressLine3 { get; set; }
        public string CCity { get; set; }
        public string CPostalCode { get; set; }
        public string TelePhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string PAddressLine1 { get; set; }
        public string PAddressLine2 { get; set; }
        public string PAddressLine3 { get; set; }
        public string PCity { get; set; }
        public string PPostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateHccCommandHandler : IRequestHandler<CreateHealthcareCenterCommand, Response<Guid>>
    {
        private readonly IHealthcareCenterRepositoryAsync _hccRepository;
        private readonly IMapper _mapper;

        public CreateHccCommandHandler(IHealthcareCenterRepositoryAsync hccRepository, IMapper mapper)
        {
            _hccRepository = hccRepository;
            _mapper = mapper;
        }
        public async Task<Response<Guid>> Handle(CreateHealthcareCenterCommand request, CancellationToken cancellationToken)
        {
            var hcc = _mapper.Map<HealthcareCenter>(request);
            hcc.CreatedDate = DateTime.UtcNow;
            
            var hccObject = await _hccRepository.AddAsync(hcc).ConfigureAwait(false);
            return new Response<Guid>(Convert.ToString(hccObject.HccId));
        }
    }
}
