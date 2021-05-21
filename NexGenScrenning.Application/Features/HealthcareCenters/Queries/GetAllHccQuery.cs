using AutoMapper;
using MediatR;
using NexGenScreening.Application.DTOs;
using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Application.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.Queries
{
    public class GetAllHccQuery : IRequest<Response<IEnumerable<HealthcareCenterViewModel>>>
    {
        public long ClientId { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetAllHccQueryHandler : IRequestHandler<GetAllHccQuery, Response<IEnumerable<HealthcareCenterViewModel>>>
    {
        private readonly IHealthcareCenterRepositoryAsync _hccRepository;
        private readonly IMapper _mapper;

        public GetAllHccQueryHandler(IHealthcareCenterRepositoryAsync hccRepository, IMapper mapper)
        {
            _hccRepository = hccRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<HealthcareCenterViewModel>>> Handle(GetAllHccQuery request, CancellationToken cancellationToken)
        {
            var hccList = (await _hccRepository.FindByCondition(x => x.ClientId == request.ClientId).ConfigureAwait(false)).AsQueryable().ToList();
            return new Response<IEnumerable<HealthcareCenterViewModel>>(_mapper.Map<IEnumerable<HealthcareCenterViewModel>>(hccList));
        }
    }
}
