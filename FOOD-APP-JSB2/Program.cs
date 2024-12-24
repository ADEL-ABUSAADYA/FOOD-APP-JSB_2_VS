using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.Configrations;
namespace FOOD_APP_JSB_2
{
    public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // builder.Services.AddScoped<IRepository<Recipe>, Repository<Recipe>>();

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(container => container.RegisterModule(new AutoFacModule()));

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddMediatR(typeof(Program).Assembly);

        var app = builder.Build();


        AutoMapperService._mapper = app.Services.GetService<IMapper>();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
}
