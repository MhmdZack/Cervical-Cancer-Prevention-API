using AutoMapper;
using MediatR;
using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Application.Wrappers;
using NexGenScreening.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.Application.Features.Sample.Commands
{
    public partial class CreateMyTestCommand : IRequest<Response<string>>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
    }

    public class CreateMyTestCommandHandler : IRequestHandler<CreateMyTestCommand, Response<string>>
    {
        private readonly IMyTestRepositoryAsync _myTestRepository;
        private readonly IMapper _mapper;

        public CreateMyTestCommandHandler(IMyTestRepositoryAsync myTestRepository, IMapper mapper)
        {
            _myTestRepository = myTestRepository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateMyTestCommand request, CancellationToken cancellationToken)
        {
            var oSample = _mapper.Map<MySample>(request);
            oSample.CreatedDate= DateTime.UtcNow;

            var EmployeeObject = await _myTestRepository.AddAsync(oSample).ConfigureAwait(false);
            return new Response<string>(Convert.ToString(EmployeeObject.Id));
        }
    }
}
