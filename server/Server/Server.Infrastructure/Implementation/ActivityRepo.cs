using Server.Application.Contract;
using Server.Core.Entities;

namespace Server.Infrastructure.Implementation;

public class ActivityRepo:BaseRepo<Activity>,IActivityRepo
{
    public ActivityRepo(IStoreContext context) : base(context)
    {
    }
}