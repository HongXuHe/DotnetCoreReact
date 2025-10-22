using AutoMapper;
using MediatR;
using Server.Application.Contract;
using Server.Application.DTOs;
using ActivityEntity =Server.Core.Entities.Activity;

namespace Server.Application.Features.Activity.Command;

public class CreateActivity
{
    public record Command(CreateActivityDto dto): IRequest<string>
    {
        
    }

    public class CreateActivityHandler(IActivityRepo activityRepo,IMapper mapper) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<ActivityEntity>(request.dto);
            entity.Id = Guid.NewGuid().ToString();
           await activityRepo.AddAsync(entity);
           return entity.Id;
        }
    }
}