using Microsoft.EntityFrameworkCore;
using StaffSkill.Repository;
using StaffSkill;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Добавляем DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрируем репозиторий
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Добавляем Swagger
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