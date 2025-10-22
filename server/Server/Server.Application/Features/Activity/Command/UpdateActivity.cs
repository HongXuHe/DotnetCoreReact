using AutoMapper;
using MediatR;
using Server.Application.Contract;
using Server.Application.DTOs;

namespace Server.Application.Features.Activity.Command;

public class UpdateActivity
{
    public record Command(string id, UpdateActivityDto dto):IRequest<Unit>;

    public class UpdateActivityHandler(IActivityRepo repo, IMapper mapper) : IRequestHandler<Command, Unit>
    {
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            if(request.id !=request.dto.Id) throw new Exception("id not match");
            var entity = await repo.GetByIdAsync(request.id);
            if(entity == null) throw new Exception("entity not found");
            mapper.Map(request.dto, entity);
            await repo.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}