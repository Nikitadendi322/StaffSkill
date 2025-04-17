var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Настройка Swagger для всех окружений (не только Development)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StaffSkills API");
    c.RoutePrefix = "swagger"; // Делает Swagger доступным по /swagger
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();