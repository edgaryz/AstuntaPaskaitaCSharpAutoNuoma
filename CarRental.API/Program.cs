using CarRental.Core.Contracts;
using CarRental.Core.Repositories;
using CarRental.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//file system
builder.Services.AddTransient<IClientRepository, ClientsDbRepository>(_ => new ClientsDbRepository("clients.csv"));
builder.Services.AddTransient<ICarsRepository, CarsDbRepository>(_ => new CarsDbRepository("clients.csv"));
//repo
builder.Services.AddTransient<ICarsRepository, CarsDbRepository>(_ => new CarsDbRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;"));
builder.Services.AddTransient<IClientRepository, ClientsDbRepository>(_ => new ClientsDbRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;"));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>(_ => new EmployeeRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;"));
builder.Services.AddTransient<IRentOrderRepository, OrdersDbRepository>(_ => new OrdersDbRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;"));
//services
builder.Services.AddTransient<ICarsService, CarsService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IRentOrderService, RentOrderService>();
builder.Services.AddTransient<ICarRentService, CarRentService>();

/*
IClientService clientService = new ClientService(clientRepository);
ICarsService carService = new CarsService(carsRepository);
IRentOrderService rentOrderService = new RentOrderService(rentOrderRepository, carsRepository, clientRepository);
IEmployeeService employeeService = new EmployeeService(employeeRepository);*/

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