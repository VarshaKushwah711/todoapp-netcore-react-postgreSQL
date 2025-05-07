using TodoApp.API.Data;
using Microsoft.EntityFrameworkCore;
using TodoApp.API.Mappings;

//Creating the Builder:
var builder = WebApplication.CreateBuilder(args);

//Adding DB Context:
builder.Services.AddDbContext<TodoContext>(options => //lambda expression
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();
app.Run();
