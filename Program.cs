global using SimpleEmailApplication.Services.EmailServices;
global using SimpleEmailApplication.Models;
global using SimpleEmailApplication.Data;
global using Microsoft.EntityFrameworkCore;
using SimpleEmailApplication.Services.OtpGeneration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add the database connection


//builder.Services.AddDbContext<EmailVerificationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddDbContext<EmailOtpAuthContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn"));
});




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IOtpService, OtpService>();

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
