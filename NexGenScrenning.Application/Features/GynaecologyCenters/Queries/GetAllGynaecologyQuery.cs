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
    public class GetAllGynaecologyQuery : IRequest<Response<IEnumerable<GynaCenterViewModel>>>
    {
        public long ClientId { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetAllGynaecologyQueryHandler : IRequestHandler<GetAllGynaecologyQuery, Response<IEnumerable<GynaCenterViewModel>>>
    {
        private readonly IGynaecologyCenterRepositoryAsync _gynRepositry;
        private readonly IMapper _mapper;

        public GetAllGynaecologyQueryHandler(IGynaecologyCenterRepositoryAsync gynRepositry, IMapper mapper)
        {
            _gynRepositry = gynRepositry;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GynaCenterViewModel>>> Handle(GetAllGynaecologyQuery request, CancellationToken cancellationToken)
        {
            var gynaList = (await _gynRepositry.FindByCondition(x => x.ClientId == request.ClientId).ConfigureAwait(false)).AsQueryable().ToList();
            return new Response<IEnumerable<GynaCenterViewModel>>(_mapper.Map<IEnumerable<GynaCenterViewModel>>(gynaList));
        }
    }
}
