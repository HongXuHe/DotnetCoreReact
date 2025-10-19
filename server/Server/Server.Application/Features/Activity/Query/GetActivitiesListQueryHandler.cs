using AutoMapper;
using MediatR;
using Server.Application.Contract;
using Server.Application.DTOs;

namespace Server.Application.Features.Activity.Query;

public record GetActivitiesListQuery() : IRequest<List<ActivityDto>>;

public class GetActivitiesListQueryHandler:IRequestHandler<GetActivitiesListQuery,List<ActivityDto>>
{
    private readonly IActivityRepo _activityRepo;
    private readonly IMapper _mapper;

    public GetActivitiesListQueryHandler(IActivityRepo activityRepo, IMapper  mapper)
    {
        _activityRepo = activityRepo;
        _mapper = mapper;
    }
    public async Task<List<ActivityDto>> Handle(GetActivitiesListQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<ActivityDto>>(await _activityRepo.GetListAsync(x=>true));
    }
}