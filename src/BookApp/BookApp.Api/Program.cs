using BookApp.Common.report;
using BookApp.Domain.Services;
using BookApp.Domain.Validators;
using BookApp.Infrastructure.Context;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

//Microsoft.Playwright.Program.Main(["install"]);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IReportBookService, ReportBookService>();
builder.Services.AddScoped<BookViewGenerate>();

builder.Services.AddProblemDetails();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookRequestValidator>());

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(police =>
    {
        police.AllowAnyOrigin();
        police.AllowAnyHeader();
        police.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
