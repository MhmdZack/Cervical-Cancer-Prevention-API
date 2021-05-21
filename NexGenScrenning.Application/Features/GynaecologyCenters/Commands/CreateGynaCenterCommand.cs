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
    public partial class CreateGynaCenterCommand : IRequest<Response<int>>
    {
        public string GynCenterCode { get; set; }
        public string GyncCenterName { get; set; }
        public int HealthCenterId { get; set; }
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
        public string ContactInfo { get; set; }
        public string AdditionalInfo { get; set; }
        public string MapUrl { get; set; }
        public long XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int IsActive { get; set; }
        public long ClientId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateGynaCenterCommandHandler : IRequestHandler<CreateGynaCenterCommand, Response<int>>
    {
        private readonly IGynaecologyCenterRepositoryAsync _gynaRepository;
        private readonly IMapper _mapper;

        public CreateGynaCenterCommandHandler(IGynaecologyCenterRepositoryAsync gynaRepository, IMapper mapper)
        {
            _gynaRepository = gynaRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGynaCenterCommand request, CancellationToken cancellationToken)
        {
            var gyna = _mapper.Map<GynaCenter>(request);
            gyna.CreatedDate = DateTime.UtcNow;

            var gynaObject = await _gynaRepository.AddAsync(gyna).ConfigureAwait(false);
            return new Response<int>(gynaObject.GynId);
        }
    }
}
