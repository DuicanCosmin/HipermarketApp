using HipermarketApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HipermarketAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HipermarketAppContext") ?? throw new InvalidOperationException("Connection string 'HipermarketAppContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.Configure<IdentityOptions>(options => options.Password.RequiredLength = 2) ;
builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => 
                                     {
                                         options.SignIn.RequireConfirmedAccount = false;
                                         options.Password.RequiredLength = 8;
                                         options.Password.RequireNonAlphanumeric = false;
                                         }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders(); 
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
//app.UseMvc();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
