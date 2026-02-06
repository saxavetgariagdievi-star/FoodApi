using FoodApi.Data;
using FoodApi.Interfaces.Services;
using FoodApi.Reposities;
using FoodApi.Reposities.interfaces;
using FoodApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1️⃣ DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2️⃣ Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

// 3️⃣ Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

// 4️⃣ AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// 5️⃣ Controllers
builder.Services.AddControllers();

// 6️⃣ Swagger
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





