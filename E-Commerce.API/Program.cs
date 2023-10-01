using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Command.Category.CreateCategory;
using E_Commerce.Application.Validations;
using E_Commerce.Application.Validations.ProductValidation;
using E_Commerce.Shared;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<E_CommerceDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlCon"), configure =>
    {
        configure.MigrationsAssembly("E-Commerce.Shared");

    });

});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;

});
// ValidationBehavior'ý pipeline içine ekleyin
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));



builder.Services.AddMediatR(typeof(CreateCategoryCommandRequest).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
