using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Trendyol API Gateway",
        Version = "v1",
        Description = "Bu API Gateway, client mikro servisler arasında yönlendirme yapar.",
        Contact = new OpenApiContact
        {
            Name = "Destek Ekibi",
            Email = "support@example.com",
            Url = new Uri("https://example.com/support")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Elonky Client API Gateway v1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();