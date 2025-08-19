using AgroVA.Domain.Account;
using AgroVA.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureAPI(builder.Configuration, builder.Environment);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();
builder.Services.AddCors(options =>
{
    //options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:5173") // origem específica
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
    );

});

var app = builder.Build();


//app.Use(async (context, next) =>
//{
//    var user = context.User;
//    if (user?.Identity?.IsAuthenticated == true)
//    {
//        Console.WriteLine("Usuário autenticado: " + user.Identity.Name);
//        Console.WriteLine("Claims:");
//        foreach (var claim in user.Claims)
//        {
//            Console.WriteLine($" - {claim.Type}: {claim.Value}");
//        }
//    }
//    else
//    {
//        Console.WriteLine("Usuário não autenticado.");
//    }

//    await next();
//});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() | app.Environment.IsStaging())
{
    if (app.Environment.IsStaging())
        SeedUserRoles(app);

    app.UseSwagger(c =>
    {
        c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
    });
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseStatusCodePages();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

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
