using Microsoft.EntityFrameworkCore;
using StaffSkill.Repository;
using StaffSkill;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ��������� DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ������������ �����������
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// ��������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();