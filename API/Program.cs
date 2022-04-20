using DAL;
using DAL.DbObjects;
using DAL.Repos;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
builder.Services.AddCors(c => c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddScoped<CategoryService, CategoryService>();
builder.Services.AddScoped<UserService, UserService>();

builder.Services.AddIdentity<DbUser, IdentityRole>(options => options.User.RequireUniqueEmail = true)
	.AddEntityFrameworkStores<ShopContext>()
	.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
	var key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Key").Value);
	
	option.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(key),
		ValidateIssuer = false,
		ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Value,
		ValidateAudience = false,
		ValidAudience = builder.Configuration.GetSection("JWT:Audience").Value,

		// Change to true if refresh tokens are used
		ValidateLifetime = false,
	};
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    TestDataSeeder.Initialize(services);
}

app.UseCors(options => {
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
});

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
