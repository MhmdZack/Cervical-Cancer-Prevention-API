using AutoMapper;
using MediatR;
using NexGenScreening.Application.DTOs;
using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Application.Wrappers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.Queries
{
    public class GetHccByHccCode : IRequest<Response<HealthcareCenterViewModel>>
    {
        public string HccCode { get; set; }
        public long ClientId { get; set; }

    }

    public class GetHccByHccCodeHandler : IRequestHandler<GetHccByHccCode, Response<HealthcareCenterViewModel>>
    {
        private readonly IHealthcareCenterRepositoryAsync _hccRepository;
        private readonly IMapper _mapper;

        public GetHccByHccCodeHandler(IHealthcareCenterRepositoryAsync hccRepository, IMapper mapper)
        {
            _hccRepository = hccRepository;
            _mapper = mapper;
        }

        public async Task<Response<HealthcareCenterViewModel>> Handle(GetHccByHccCode request, CancellationToken cancellationToken)
        {
            var hccObject = (await _hccRepository.FindByCondition(x => x.HccCode.ToLower().Equals(request.HccCode.ToLower()) && x.ClientId == request.ClientId).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            return new Response<HealthcareCenterViewModel>(_mapper.Map<HealthcareCenterViewModel>(hccObject));
        }
    }
}
