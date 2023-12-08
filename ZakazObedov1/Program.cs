using Microsoft.EntityFrameworkCore;
using ZakazObedov1.DataAccess;
using ZakazObedov1.DataAccess.Repository;
using ZakazObedov1.DataAccess.Repository.Contracts;
using ZakazObedov1.Mappings;
using ZakazObedov1.Services;
using ZakazObedov1.Services.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");
if (string.IsNullOrEmpty(connectionString))
{
    throw new ApplicationException("Could not load 'Default' connection string");
}
builder.Services.AddDbContext<ZakazObedov1DBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddAutoMapper(typeof(OrderProfile));
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddAutoMapper(typeof(MealProfile));
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddAutoMapper(typeof(RestaurantProfile));
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
