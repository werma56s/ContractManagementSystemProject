using ContractManagementSystem.DAL.Services;
using ContractManagementSystem.DAL.Services.Interfaces;
using ContractManagementSystem.Core;
using Microsoft.EntityFrameworkCore;
using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using ContractManagementSystem.BL.BusinessLogicServices;
using ContractManagementSystem.DAL.Assemblers;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add AutoMapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container. (db, unitOfWork)
builder.Services.AddDbContext<ContractManagementDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IAddendumService, AddendumService>();
//builder.Services.AddScoped<IProductItemService, ProductItemService>();
//builder.Services.AddScoped<IResponsiblePersonService, ResponsiblePersonService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<ContractAssemblers>();
builder.Services.AddSingleton<CategoryAssemblers>();


var app = builder.Build();

// Configure the HTTP request pipeline.

//swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contract Management API v1");
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
