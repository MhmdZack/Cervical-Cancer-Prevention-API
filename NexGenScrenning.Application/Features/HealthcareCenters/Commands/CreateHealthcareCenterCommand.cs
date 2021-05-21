using AutoMapper;
using MediatR;
using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Application.Wrappers;
using NexGenScreening.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.Commands
{
    public partial class CreateHealthcareCenterCommand : IRequest<Response<int>>
    {
        //public int HccId { get; set; }
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
        public int IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateHccCommandHandler : IRequestHandler<CreateHealthcareCenterCommand, Response<int>>
    {
        private readonly IHealthcareCenterRepositoryAsync _hccRepository;
        private readonly IMapper _mapper;

        public CreateHccCommandHandler(IHealthcareCenterRepositoryAsync hccRepository, IMapper mapper)
        {
            _hccRepository = hccRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateHealthcareCenterCommand request, CancellationToken cancellationToken)
        {
            var hcc = _mapper.Map<HealthcareCenter>(request);
            hcc.CreatedDate = DateTime.UtcNow;

            var hccObject = await _hccRepository.AddAsync(hcc).ConfigureAwait(false);
            return new Response<int>(hccObject.HccId);
        }
    }
}
