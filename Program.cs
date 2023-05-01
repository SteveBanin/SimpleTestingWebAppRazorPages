using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Data;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TestingWebAppRazorPagesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestingWebAppRazorPagesContext") ?? throw new InvalidOperationException("Connection string 'TestingWebAppRazorPagesContext' not found.")));


var app = builder.Build();


// Adding the scope of movie seeding data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedingDataInitializer.Initializer(services);
}


// Adding the scope of Producer seeding data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedingDataInitializerForProducers.Initializer(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//Below code enables various Middleware

app.UseHttpsRedirection(); // To redirect HTTP requests to HTTPS.

app.UseStaticFiles(); //  To enable static files

app.UseRouting(); // To add route matching to the middleware pipeline.


// Core 
app.UseAuthorization(); // To authorize a user to access secure resources. 

app.MapRazorPages(); // To configure endpoint routing for Razor Pages.

app.Run(); // To run the app.
