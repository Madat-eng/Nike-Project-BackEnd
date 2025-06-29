using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// ===== ÅÖÇÝÉ CORS åäÇ =====
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // ÇáÓãÇÍ áÃí ãÕÏÑ (Ýí ÇáÈíÆÉ ÇáÊäãæíÉ ÝÞØ)
              .AllowAnyMethod()  // ÇáÓãÇÍ ÈÌãíÚ ØÑÞ HTTP (GET, POST, etc.)
              .AllowAnyHeader(); // ÇáÓãÇÍ ÈÌãíÚ ÇáÜ Headers
    });
});

// Configure API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

// Configure Versioned API Explorer (for Swagger)
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "API v1", Version = "1.0" });
});

var app = builder.Build();

// ===== Êãßíä CORS Middleware åäÇ =====
app.UseCors("AllowAll"); // íÌÈ æÖÚå ÞÈá UseRouting/UseEndpoints

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();