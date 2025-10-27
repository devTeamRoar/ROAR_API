using Microsoft.EntityFrameworkCore;
using RoarIndustriesApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Define a specific name for your CORS policy
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

// Add and configure the CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Add the origins your frontend is hosted on
                          policy.WithOrigins("http://localhost:3000",
                                             "https://roar-industries.vercel.app",
                                             "https://roarindustries.in",
                                             "https://www.roarindustries.in")
                                .AllowAnyHeader() // Allows all headers
                                .AllowAnyMethod(); // Allows all methods (GET, POST, etc.)
                      });
});


// Register the DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply the CORS middleware
// This must be placed after UseHttpsRedirection and before UseAuthorization
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
