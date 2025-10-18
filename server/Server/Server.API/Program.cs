using System.Reflection;
using Server.Application.Contract;
using Server.Application.Features.Product;
using Server.Application.Features.Product.Query;
using Server.Core.Entities;
using Server.Infrastructure;
using Server.Infrastructure.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(c => c.AddProfile(typeof(ProductProfile)));
//builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(GetProductByIdQueryHandler).Assembly));

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
InitDb(app.Services);
app.MapControllers();
app.Run();


static void InitDb(IServiceProvider provider)
{
    using (var scope = provider.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
        context.Database.EnsureCreated();
        if (context.Products.Any())
        {
            return;
        }
        context.Products.Add(new Product()
        {
            Name = "test11"
        });
        context.SaveChanges();
    }
}
