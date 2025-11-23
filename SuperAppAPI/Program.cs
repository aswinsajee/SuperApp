using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using SuperAppAPI.Data;
using SuperAppAPI.Mapping;
using SuperAppAPI.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy => policy
            .WithOrigins("https://localhost:5001", "http://localhost:5000", "https://localhost:7196")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers(); 
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection to DB
builder.Services.AddDbContext<SuperAppAuthDBContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("SuperAppAuthConnectionString")));

builder.Services.AddDbContext<SuperAppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("SuperAppConnectionString")));

builder.Services.AddScoped<IPlatformRepository, SQLPlatformRepository>(); //inject the interface and implement the repositor
builder.Services.AddScoped<IPayementRepository, SQLPayementRepository>(); //inject the interface and implement the repositor
builder.Services.AddScoped<IPlansRepository, SQLPlansRepository>();//inject the interface and implement the repositor
builder.Services.AddScoped<ITokenRepository, SQLTokenRepositoryc>(); //inject the interface and implement the repositor
builder.Services.AddScoped<ISubUserRepository, SQLSubUsersRepository>();//inject the interface and implement the repositor
builder.Services.AddScoped<ISubscribedPlansRepostiory, SQLSubscribedPlansRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

//SetupIdentity
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("SuperApp")
    .AddEntityFrameworkStores<SuperAppAuthDBContext>()
    .AddDefaultTokenProviders();

//Setup IdentityOptions

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;


});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
    });

var app = builder.Build();

app.UseCors("AllowBlazor");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
if (!Directory.Exists(imagePath))
{
    Directory.CreateDirectory(imagePath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagePath),
    RequestPath = "/Images"
});

app.MapControllers();

app.Run();
