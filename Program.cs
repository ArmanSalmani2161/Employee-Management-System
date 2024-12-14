using Microsoft.EntityFrameworkCore;
using webapi.Repositories;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddCors(options => {
//     options.AddPolicy("MyAllowPoliciy", builder => {
//         builder.WithOrigins("").AllowAnyHeader().AllowAnyMethod();
//     });
// });

builder.Services.AddDbContextPool<EmployeeDbContext>(
    op => op.UseMySql(builder.Configuration.GetConnectionString("DbConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DbConnection")))
);
builder.Services.AddScoped<IEmployeeService, EmployeeServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
