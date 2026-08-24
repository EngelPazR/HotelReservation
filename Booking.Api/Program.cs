using Booking.Api;
using Booking.Api.Services;
using Booking.Api.Services.Abstrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DataSource>();
builder.Services.AddSingleton<MyFirstService>();
builder.Services.AddSingleton<ISingleOperation, SingleonOperation>();
builder.Services.AddTransient<ITrasientOperation, TrasientOperation>();
builder.Services.AddScoped<IScopedOperation, ScopedOperation>();

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
