using CarBookProject.Application.Services;
using CarBookProject.WebApi.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomServices(builder.Configuration);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
