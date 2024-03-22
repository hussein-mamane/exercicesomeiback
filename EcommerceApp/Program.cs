using EcommerceApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("frontangular",
//         policy =>
//         {
//             policy.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader();
//         });
// });

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options=>
    options.UseSqlite(builder.Configuration.GetConnectionString("mysqlite")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());
// app.UseCors("frontangular");
app.UseHttpsRedirection();

app.MapControllers();
app.Run();

