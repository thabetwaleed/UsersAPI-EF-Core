using Microsoft.EntityFrameworkCore;
using UsersAPI.Model;
using UsersAPI.Repos;
using UsersAPI.Extensions;
using UsersAPI;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.myser(builder.Configuration);
    

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//For automapper
//builder.Services.AddAutoMapper(typeof(Profile));


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
//app.UseExceptionHandleMiddleware();//custom middleware

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Hello world");
//    // Do work that can write to the Response.
//    await next.Invoke();
//    // Do logging or other work that doesn't write to the Response.
//});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



//app.UseMiddleware<CustomMiddleware>();

app.Run();
