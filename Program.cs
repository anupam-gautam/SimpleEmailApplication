global using SimpleEmailApplication.Services.EmailServices;
global using SimpleEmailApplication.Models;
global using SimpleEmailApplication.Data;
global using Microsoft.EntityFrameworkCore;
using SimpleEmailApplication.Services.OtpGeneration;

using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


//Google and Facebook Login Auth Configuration 
builder.Services.AddAuthentication().AddGoogle(googleoptions =>
{
    googleoptions.ClientId = "888792722174-ou49vl5oph7qf5f006o1e1rtpjjh39vn.apps.googleusercontent.com";
    googleoptions.ClientSecret = "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";
})
.AddFacebook(facebookoptions =>
{
    facebookoptions.AppId = "1535037343619428";
    facebookoptions.AppSecret = "513dc68ed1079eb25cec7b0952f3170c";
})
.AddGoogle(googleoptions =>
{
    googleoptions.ClientId = "888792722174-t937desh0knd6bojh43vmsvsqse4et3q.apps.googleusercontent.com";
    googleoptions.ClientSecret = "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";
});
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

//HTML Form
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
    RequestPath = "/StaticFiles",
    EnableDefaultFiles = true
});

//app.UseDefaultFiles();
//app.UseStaticFiles();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
