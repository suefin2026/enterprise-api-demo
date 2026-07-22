using EnterpriseApi.Application.Features.Products.Queries;
using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// add react UI
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactDevelopment", policy =>
    {
        policy
            .WithOrigins("http://localhost:5174")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddScoped<GetProductsQueryHandler>();
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
// add react UI
app.UseCors("ReactDevelopment");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
