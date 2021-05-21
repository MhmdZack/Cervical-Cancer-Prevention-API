using AutoMapper;
using MediatR;
using NexGenScreening.Application.DTOs;
using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.Queries
{
    public class GetGynaCenterByCode : IRequest<Response<GynaCenterViewModel>>
    {
        public string GynCenterCode { get; set; }
        public long ClientId { get; set; }
    }

    public class GetGynaCenterByCodeHandler : IRequestHandler<GetGynaCenterByCode, Response<GynaCenterViewModel>>
    {
        private readonly IGynaecologyCenterRepositoryAsync _gynaRepository;
        private readonly IMapper _mapper;

        public GetGynaCenterByCodeHandler(IGynaecologyCenterRepositoryAsync gynaRepository, IMapper mapper)
        {
            _gynaRepository = gynaRepository;
            _mapper = mapper;
        }

        public async Task<Response<GynaCenterViewModel>> Handle(GetGynaCenterByCode request, CancellationToken cancellationToken)
        {
            var gynaObject = (await _gynaRepository.FindByCondition(x => x.GynCenterCode.ToLower().Equals(request.GynCenterCode.ToLower()) && x.ClientId == request.ClientId).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            return new Response<GynaCenterViewModel>(_mapper.Map<GynaCenterViewModel>(gynaObject));
        }
    }
}
