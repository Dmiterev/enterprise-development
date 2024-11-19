using Microsoft.EntityFrameworkCore;
using RecrAgency.Api.DTO;
using RecrAgency.Api.Services;
using RecrAgency.Api.Services.Interfaces;
using RecrAgency.Domain;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� ���� ������ � �������������� PostgreSQL
builder.Services.AddDbContext<RecrAgencyContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("RecrAgency.Api")));

// ��������� Swagger � XML-�������������
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// ����������� ��������
builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<IJobSeekersService, JobSeekerService>();
builder.Services.AddScoped<IPositionsService, PositionService>();
builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();
builder.Services.AddScoped<IEmployerApplicationService, EmployerApplicationService>();

// ���������� ������������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// �������������� ���������� �������� ��� ������� ����������
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RecrAgencyContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
