using Server.Application.Contract;
using Server.Core.Entities;

namespace Server.Infrastructure.Implementation;

public class ProductRepo:BaseRepo<Product>,IProductRepo
{
    public ProductRepo(IStoreContext context) : base(context)
    {
        
    }
}