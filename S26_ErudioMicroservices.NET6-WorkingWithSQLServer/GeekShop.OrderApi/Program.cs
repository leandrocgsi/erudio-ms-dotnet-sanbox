using GeekShop.OrderApi.MessageConsumer;
using GeekShop.OrderApi.Model.Context;
using GeekShop.OrderApi.Repository;
using GeekShop.OrderAPI.MessageConsumer;
using GeekShop.OrderAPI.RabbitMQSender;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Add DataContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

//Create dbContext variable
var dbContextBuilder = new DbContextOptionsBuilder<DataContext>();
dbContextBuilder.UseSqlServer(connection);

//Add Dependency injection
builder.Services.AddSingleton(new OrderRepository(dbContextBuilder.Options));

//Add dependecy injection - MessageBus
builder.Services.AddHostedService<RabbitMQCheckoutConsumer>();
builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();

//Add Host Service
builder.Services.AddHostedService<RabbitMQCheckoutConsumer>();
builder.Services.AddHostedService<RabbitMQPaymentConsumer>();

// Add services to the container.
builder.Services.AddControllers();

//Add authentication
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:4435";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false
    };
    options.RequireHttpsMetadata = false;
});

//Add authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "geek_shop");
    });
});

//Add swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShop.OrderApi", Version = "v1" });    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token!",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
           Scheme = "oauth2",
            Name = "Bearer",
            In= ParameterLocation.Header
        },
        new List<string> ()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeekShop.OrderApi v1"));
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

