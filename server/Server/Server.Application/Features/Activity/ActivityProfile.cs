using AutoMapper;
using Server.Application.DTOs;
using ActivityEntity = Server.Core.Entities.Activity;
namespace Server.Application.Features.Activity;

public class ActivityProfile: Profile
{
    public ActivityProfile()
    {
        CreateMap<ActivityEntity, ActivityDto>().ReverseMap();
    }
}