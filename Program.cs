using AutoMapper;
using PizzaPlaceSalesAPI.EFConfigurations;
using PizzaPlaceSalesAPI;
using System;
using PizzaPlaceSalesAPI.Data;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Services.Order_Detail_Services;
using PizzaPlaceSalesAPI.Services.Order_Services;
using PizzaPlaceSalesAPI.Services.Pizza_Services;
using PizzaPlaceSalesAPI.Services.Pizza_Type_Services;
using PizzaPlaceSalesAPI.Repositories;
using PizzaPlaceSalesAPI.Services.CSVServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var AllowedOrigins = "_allowedOrigins";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("AllowedOrigins", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

//Repository
builder.Services.AddScoped<Order_Repository>();
builder.Services.AddScoped<Order_Detail_Repository>();
builder.Services.AddScoped<Pizza_Repository>();
builder.Services.AddScoped<Pizza_Type_Repository>();

//Add Mapper Configuration
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperConfig());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//Add SeriLogger Configuration
builder.Services.AddSingleton(typeof(SeriLogger));

// Add services to the container.
builder.Services.AddScoped<IPizza_Service, Pizza_Service>();
builder.Services.AddScoped<IPizza_Type_Service, Pizza_Type_Service>();
builder.Services.AddScoped<IOrder_Service, Order_Service>();
builder.Services.AddScoped<IOrder_Detail_Service, Order_Detail_Service>();
builder.Services.AddScoped<ICSVService, CSVService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Pizza Place Sales API", Version = "v1" });

    // Set the XML comments path for Swagger JSON and UI
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza Place Sales API V1");
    });
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza Place Sales API V1");
});

app.UseHttpsRedirection();

app.UseCors(AllowedOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
