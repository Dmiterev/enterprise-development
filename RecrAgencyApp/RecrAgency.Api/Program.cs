using Microsoft.EntityFrameworkCore;
using RecrAgency.Api.Services;
using RecrAgency.Api.Services.Interfaces;
using RecrAgency.Domain;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<RecrAgencyContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 39))));

builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<IJobSeekersService, JobSeekerService>();
builder.Services.AddScoped<IPositionsService, PositionService>();
builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();
builder.Services.AddScoped<IEmployerApplicationService, EmployerApplicationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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