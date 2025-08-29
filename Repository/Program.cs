using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using Repository.Application.Interfaces;
using Repository.Application.Services;
using Repository.Infrastructure.EventBus.RabbitMQ;
using Repository.Infrastructure.Repositories;
using Repository.Infrastructure.Repositories.MSSql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<SiteViewAnalysisContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SiteViewAnalysisDB")));
//builder.Services.AddDbContext<SiteViewAnalysisContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("SiteViewAnalysisDB")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISiteVisitsRepository, MSSqlRepository>();
builder.Services.AddScoped<SiteVisitsService>();
builder.Services.AddSingleton<INotification, EventBus>();

// RabbitMq
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection(RabbitMqConfiguration.Section));
builder.Services.AddSingleton<IConnectionFactory>(provider =>
{
    var factory = new ConnectionFactory
    {
        HostName = builder.Configuration["RabbitMq:Host"],
        AutomaticRecoveryEnabled = true,
        ConsumerDispatchConcurrency = 1 // Configure the amount of concurrent consumers within one host
    };
    return factory;
});
builder.Services.AddSingleton<IConnectionProvider, ConnectionProvider>();
builder.Services.AddSingleton<IChannelProvider, ChannelProvider>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        //policy.WithOrigins("https://website-theta-two-58.vercel.app")
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.Run();
