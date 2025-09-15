using Notification.Application;
using Notification.Application.Services;
using Notification.Infrastructure.EventBus.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<TelegramConfiguration>(builder.Configuration.GetSection(TelegramConfiguration.Section));
builder.Services.AddTransient<NotificationService>();

// RabbitMq
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection(RabbitMqConfiguration.Section));
builder.Services.AddSingleton<IConnectionProvider, ConnectionProvider>();
builder.Services.AddSingleton<IChannelProvider, ChannelProvider>();
builder.Services.AddHostedService<EventBus>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
