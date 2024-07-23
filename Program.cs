using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProjectManagementAPIB.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProjectManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectManagementConnection")));

builder.Services.AddControllers();

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader();
        });
});

// Ensure JWT configuration values are present
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
{
    throw new ArgumentNullException("Jwt configuration values cannot be null or empty.");
}

// Configure authentication with JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

// Register the Telerik Reporting services
/* builder.Services.AddScoped<IReportServiceConfiguration>(sp =>
{
    var reportServiceConfiguration = new ReportServiceConfiguration
    {
        HostAppId = "MyApp",
        Storage = new FileStorage(),
        ReportResolver = new ReportResolver(),
        ReportSharingTimeout = 60,
        ClientSessionTimeout = 20
    };
    return reportServiceConfiguration;
});
*/
// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

// Commented out for HTTP use only
// app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication(); // Ensure this is called before UseAuthorization
app.UseAuthorization();

app.MapControllers();

/*
// Register the route for the Telerik Reporting REST service
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapReportingService("/api/reports", sp => sp.GetRequiredService<IReportServiceConfiguration>());
});
*/
app.Run();

/*

// Report resolver implementation
public class ReportResolver : IReportResolver
{
    public ReportSource Resolve(string reportId)
    {
        var reportSource = new UriReportSource()
        {
            Uri = $"~/Reports/{reportId}.trdp"
        };
        return reportSource;
    }
}
*/