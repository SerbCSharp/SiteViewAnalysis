using Notification.Application.Interfaces;
using Notification.Infrastructure.EventBus.RabbitMQ;
using Notification.Presentation;
using Notification.Presentation.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISendMessage, TelegramController>();
builder.Services.Configure<TelegramConfiguration>(builder.Configuration.GetSection(TelegramConfiguration.Section));
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection(RabbitMqConfiguration.Section));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
