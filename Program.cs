using FinalYearProject.Data;
using FinalYearProject.Services.patientService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using FinalYearProject.Services.patientService.AppointmentService;
using FinalYearProject.Services.patientService.XrayService;
using System.Net.Http.Headers;
using FinalYearProject.Services.patientService.DoctorService;
using FinalYearProject.Services.patientService.TreatmentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//
ConfigurationManager configuration = builder.Configuration;

var encryptionstring = configuration.GetSection("AppSettings:Token");

builder.Services.AddDbContext<DataContext>(options=>
options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddScoped<IAppService, AppService>();
builder.Services.AddScoped<IpatientService, patientService>();
builder.Services.AddScoped<IXrayService,XrayService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<ITreatmentService,TreatmentService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
{
    Description = "Standard Authorization header using the Bearer Scheme. Example \"bearer {token}\"",
    In=ParameterLocation.Header, 
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey
});
c.OperationFilter<SecurityRequirementsOperationFilter>();
}
);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>
{
    options.TokenValidationParameters= new TokenValidationParameters
    {
        ValidateIssuerSigningKey=true,
        IssuerSigningKey= new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(encryptionstring.Value)),
        ValidateIssuer=false,
        ValidateAudience=false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
