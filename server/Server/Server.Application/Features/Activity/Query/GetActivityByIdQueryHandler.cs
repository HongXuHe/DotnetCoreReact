using AutoMapper;
using MediatR;
using Server.Application.Contract;
using Server.Application.DTOs;

namespace Server.Application.Features.Activity.Query;

public record GetActivityByIdQuery(string Id):IRequest<ActivityDto>;
public class GetActivityByIdQueryHandler:IRequestHandler<GetActivityByIdQuery,ActivityDto>
{
    private readonly IActivityRepo _activityRepo;
    private readonly IMapper _mapper;

    public GetActivityByIdQueryHandler(IActivityRepo activityRepo, IMapper mapper)
    {
        _activityRepo = activityRepo;
        _mapper = mapper;
    }
    public async Task<ActivityDto> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        if (await _activityRepo.ExistsAsync(x=>x.Id==request.Id))
        {
            return _mapper.Map<ActivityDto>(await _activityRepo.GetByIdAsync(request.Id));
        }
        throw new KeyNotFoundException("Activity Not Found");
    }
}