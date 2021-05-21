using AutoMapper;
using MediatR;
using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Application.Wrappers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.Commands
{
    public partial class UpdateHealthcareCenterCommand : IRequest<Response<int>>
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
        public long UpdatedBy { get; set; }
        public long ClientId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class UpdateHealthcareCenterCommandHandler : IRequestHandler<UpdateHealthcareCenterCommand, Response<int>>
    {
        private readonly IHealthcareCenterRepositoryAsync _hccRepository;
        private readonly IMapper _mapper;

        public UpdateHealthcareCenterCommandHandler(IHealthcareCenterRepositoryAsync hccRepository, IMapper mapper)
        {
            _hccRepository = hccRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateHealthcareCenterCommand request, CancellationToken cancellationToken)
        {
            var oHcc = (await _hccRepository.FindByCondition(x => x.HccCode == request.HccCode && x.ClientId == request.ClientId).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            
            oHcc.HccName = request.HccName;
            oHcc.CAddressLine1 = request.CAddressLine1;
            oHcc.CAddressLine2 = request.CAddressLine2;
            oHcc.CAddressLine3 = request.CAddressLine3;
            oHcc.CCity = request.CCity;
            oHcc.CPostalCode = request.CPostalCode;
            oHcc.TelePhoneNumber = request.TelePhoneNumber;
            oHcc.MobileNumber = request.MobileNumber;
            oHcc.FaxNumber = request.FaxNumber;
            oHcc.PAddressLine1 = request.PAddressLine1;
            oHcc.PAddressLine2 = request.PAddressLine2;
            oHcc.PAddressLine3 = request.PAddressLine3;
            oHcc.PCity = request.PCity;
            oHcc.PPostalCode = request.PPostalCode;
            oHcc.EmailAddress = request.EmailAddress;
            oHcc.WebsiteUrl = request.WebsiteUrl;
            oHcc.IsActive = request.IsActive;
            oHcc.UpdatedBy = request.UpdatedBy;
            oHcc.UpdatedDate = DateTime.UtcNow;

            var hccObject = await _hccRepository.UpdateAsync(oHcc).ConfigureAwait(false);
            return new Response<int>(hccObject.HccId);
        }
    }
}
