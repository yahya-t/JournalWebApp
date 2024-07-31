using JournalWebApp.Data;
using JournalWebApp.Logic;
using JournalWebApp.Repository;
using Microsoft.EntityFrameworkCore;
using JournalWebApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// DBContexts
var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(defaultConnectionString));
var loginConnectionString = builder.Configuration.GetConnectionString("LoginContextConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<LoginContext>(options => options.UseSqlServer(loginConnectionString));
// Dependency Injections
builder.Services.AddScoped<INotesRepository, NotesRepository>();
builder.Services.AddScoped<INotesLogic, NotesLogic>();
// Require confirmed account for identity
builder.Services.AddDefaultIdentity<LoginUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LoginContext>();

var app = builder.Build();

// Seed initial data of Notes to the database
using (var scope = app.Services.CreateScope())
{
    // Get instance of DataContext class
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DataContext>();
    // Apply migrations automatically if database does not exist
    dbContext.Database.Migrate();
    // If app is in dev environment, invoke the SeedInitialData method()
    if (app.Environment.IsDevelopment())
    {
        dbContext.SeedInitialData();
    }
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
