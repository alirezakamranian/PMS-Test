using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

var builder = WebApplication.CreateBuilder(args);

//                                                         Container configuration

//Mvc Config
builder.Services.AddControllers();

//DbContext Config
builder.Services.AddDbContext<DataContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

//Swagger Config
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






//                                                    HTTP request pipeline configuration

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
