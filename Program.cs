using InvoiceSystem.DataAccess;
using InvoiceSystem.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Logging.ClearProviders();
builder.Logging.AddEventSourceLogger();
builder.Logging.AddDebug();
builder.Logging.AddConsole();
//

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddControllers();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<CategoryService>();
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<InvoiceService>();
builder.Services.AddSingleton<JsonHandler>();


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

