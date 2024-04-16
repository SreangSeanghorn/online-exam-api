using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TodoApi.Contract;
using TodoApi.Data;
using TodoApi.Data.Configuration;
using TodoApi.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoApi.Service;
using TodoApi.ServiceImp;

{
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();


        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddControllers();
        // Adding the AutoMapper
        builder.Services.AddAutoMapper(typeof(MapperConfig));
        // Adding the Service
        builder.Services.AddScoped<IAuthManager, AuthManagerImp>();
        // Adding the Repository
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<ICourseRepository, CourseRepository>(); // Ensure that CourseRepository implements ICourseRepository
    
    
    builder.Services.AddIdentityCore<Users>().AddRoles<Microsoft.AspNetCore.Identity.IdentityRole>()
        .AddEntityFrameworkStores<StudentDBContext>();

    // Configure the Corse Policy
    builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
        // Adding the Authentication
builder.Services.AddAuthentication(option =>{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
;
builder.Services.AddAuthorization();
        // Configuration to the database
        builder.Services.AddDbContext<StudentDBContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });


        var app = builder.Build();

        app.UseCors("AllowAll");
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });


        app.MapGet("/", () => "Hello World!");

        app.MapAreaControllerRoute(
            name: "course",
            areaName: "course", 
            pattern: "{controller=Course}/{action=Index}/{id?}"
        );

        app.MapAreaControllerRoute(
            name: "student",
            areaName: "student",
            pattern: "{controller=Student}/{action=Index}/{id?}"
        );
        app.MapAreaControllerRoute(
            name: "enrollment",
            areaName: "enrollment",
            pattern: "{controller=Enrollment}/{action=Index}/{id?}"
        );

        app.MapAreaControllerRoute(
            name: "authentication",
            areaName: "authentication",
            pattern: "{controller=Authentication}/{action=Index}/{id?}"
        );

        app.Run();
    
}