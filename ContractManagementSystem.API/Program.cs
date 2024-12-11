using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using ContractManagementSystem.BL.BusinessLogicServices;
using ContractManagementSystem.DAL.Services;
using ContractManagementSystem.DAL.Services.Interfaces;
using ContractManagementSystem.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IContractService, ContractService>();
//builder.Services.AddScoped<IAddendumService, AddendumService>();
//builder.Services.AddScoped<IProductItemService, ProductItemService>();
//builder.Services.AddScoped<IResponsiblePersonService, ResponsiblePersonService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddControllers();

builder.Services.AddDbContext<ContractManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
