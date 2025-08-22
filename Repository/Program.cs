using Microsoft.EntityFrameworkCore;
using Repository.Application.Interfaces;
using Repository.Application.Services;
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
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://website-theta-two-58.vercel.app")
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
