using GeekShop.Web.Services;
using GeekShop.Web.Services.IService;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

////Dependecy Injection
//builder.Services.AddMvc();

//Add Http Client
builder.Services.AddHttpClient<IProductService, ProductService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductApi"]));

builder.Services.AddHttpClient<ICartService, CartService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CartApi"]));

builder.Services.AddHttpClient<ICouponService, CouponService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CouponApi"]));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Authentications
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
  .AddOpenIdConnect("oidc", options =>
  {
      options.Authority = "https://localhost:4435";
      options.GetClaimsFromUserInfoEndpoint = true;
      options.ClientId = "geek_shop";
      options.ClientSecret = "my_super_secret";
      options.ResponseType = "code";
      options.ClaimActions.MapJsonKey("role", "role", "role");
      options.ClaimActions.MapJsonKey("sub", "sub", "sub");
      options.TokenValidationParameters.NameClaimType = "name";
      options.TokenValidationParameters.RoleClaimType = "role";
      options.Scope.Add("geek_shop");
      options.SaveTokens = true;
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();