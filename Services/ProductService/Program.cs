using Microsoft.EntityFrameworkCore;
using ProductsService.Data;
using ProductsService.Repository;
using ProductsService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ProductsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
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
    //    options.SwaggerEndpoint("http://localhost:5066/swagger/v1/swagger.json", "My API v1");
    //});
    //app.MapOpenApi();
}
app.UseRouting();
app.MapControllers();
app.UseCors("AllowAll");
//app.UseHttpsRedirection();
app.Run();


