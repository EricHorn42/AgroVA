using AgroVA.Domain.Account;
using AgroVA.Infra.Data.Identity;
using AgroVA.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllersWithViews();


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

app.UseRouting();

SeedUserRoles(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


void SeedUserRoles(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        ISeedUserRoleInitial seedUserRoleInitial = serviceScope
            .ServiceProvider
            .GetRequiredService<ISeedUserRoleInitial>();

        seedUserRoleInitial.SeedRoles();
        seedUserRoleInitial.SeedUsers();
    }    
}
