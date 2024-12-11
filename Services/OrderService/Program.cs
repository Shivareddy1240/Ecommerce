using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Repository;
using OrderService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<OrdersDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersConnection")));
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddControllers();
builder.Services.AddHttpClient("ProductsService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5066/api/Products");
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwagger(options =>
    //{
    //    options.RouteTemplate = "swagger/{documentName}/swagger.json";
    //});
    //app.UseSwaggerUI(options =>
    //{
    //    options.SwaggerEndpoint("http://localhost:5103/swagger/v1/swagger.json", "My API v1");
    //});
    //app.MapOpenApi();
}
app.UseRouting();
app.MapControllers();
app.UseCors("AllowAll");
//app.UseHttpsRedirection();
app.Run();


