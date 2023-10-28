using PruebaTecnica.Api.Apps.Api.Controllers.Extensions;
using PruebaTecnica.Api.Src.Core.Business.Dependences;
using PruebaTecnica.Api.Src.Infrastructure.Data.Dependences;
using PruebaTecnica.Api.Src.Infrastructure.Shared.Config;

var builder = WebApplication.CreateBuilder(args);
ConfigHelper.Configuration = builder.Configuration;

// Add services to the container.
builder.Services.RegisterBusiness();
builder.Services.RegisterData();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UserErrorHandlingMiddleware();

app.UseCors(builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());

app.MapControllers();

app.Run();
