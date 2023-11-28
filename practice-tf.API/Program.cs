using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using practice_tf.API.Inventory.Domain.Repositories;
using practice_tf.API.Inventory.Domain.Services;
using practice_tf.API.Inventory.Mapping;
using practice_tf.API.Inventory.Persistence.Repositories;
using practice_tf.API.Inventory.Services;
using practice_tf.API.Maintenance.Domain.Repositories;
using practice_tf.API.Maintenance.Domain.Services;
using practice_tf.API.Maintenance.Persistence.Repositories;
using practice_tf.API.Maintenance.Services;
using practice_tf.API.Shared.Persistence.Contexts;
using practice_tf.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "ISA API",
        Description = "ISA RESTful API",
        TermsOfService = new Uri("https://isa.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "ISA",
            Url = new Uri("https://isa.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "ISA Resources License",
            Url = new Uri("https://isa.com/license")
        }
    });
    options.EnableAnnotations();
});

//DB Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMaintenanceActivityRepository, MaintenanceActivityRepository>();
builder.Services.AddScoped<IMaintenanceActivityService, MaintenanceActivityService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

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