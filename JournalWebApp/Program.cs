using JournalWebApp.Data;
using JournalWebApp.Logic;
using JournalWebApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add DataContext and declare SQL server with connection string
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Dependency Injection
builder.Services.AddScoped<INotesRepository, NotesRepository>();
builder.Services.AddScoped<INotesLogic, NotesLogic>();

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
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
