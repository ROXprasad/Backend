using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TNEB.BusinessLogics.Interface;
using TNEB.BusinessLogics.Logics;
using TNEB.SAPInterface;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/myapp.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();
builder.WebHost.UseUrls("http://localhost:5000");
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IloginService, loginService>();
builder.Services.AddHttpClient<SAPOData_EmployeeProfile>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRegistration,Registration>();
builder.Services.AddControllers().AddNewtonsoftJson(options=>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    // options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
    o.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
                context.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tneb.WebApi",
        Version = "v1",
        Description = "API Documentation for Tneb Web API"
    });
});
//builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
//{
//    build.WithOrigins("http://10.236.202.84").AllowAnyHeader().AllowAnyMethod(); //https://localhost:4200 //https://192.168.35.143:4200
//}
//));
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins(allowedOrigins) // Add more origins as needed
         .AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials();
}));

//builder.Services.Add

var app = builder.Build();
// Test log
Log.Information("Application starting up...");


// Error handling middleware
app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An unhandled exception has occurred: {Message}", ex.Message);
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Internal server error.");
    }
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("corspolicy");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();