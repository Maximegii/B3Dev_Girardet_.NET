using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using mvc.Models;
using mvc.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var serverVersion = new MySqlServerVersion(new Version(11, 0, 2));
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
    );

    builder.Services.AddIdentity<Student, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 6 ;

        options.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
