using EcommerceAPI.Data;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;
using EcommerceAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar el contexto de la base de datos
builder.Services.AddSingleton<DatabaseContext>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new DatabaseContext(connectionString!);
});

// Registrar servicios y repositorios
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ProductsService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<OrdersService>();

// Add services to the container
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Ecommerce API funcionando");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();