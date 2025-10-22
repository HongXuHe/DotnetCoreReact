using MediatR;
using Server.Application.Contract;

namespace Server.Application.Features.Activity.Command;

public class DeleteActivity
{
    public record Command(string Id):IRequest<Unit>;
    public class DeleteActivityHandler(IActivityRepo activityRepo):IRequestHandler<Command,Unit>
    {
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            if(!await activityRepo.ExistsAsync(x=>x.Id==request.Id)) throw new Exception("Activity doesn't exist");
           await activityRepo.DeleteByIdAsync(request.Id);
           return Unit.Value;
        }
    }
}