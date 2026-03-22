using LMS.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add MVC
builder.Services.AddControllersWithViews();

// Add session
builder.Services.AddSession();

// Register repositories (SCOPED)
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IReaderRepository, ReaderRepository>();
builder.Services.AddScoped<IBorrowingRepository, BorrowingRepository>();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

// Default route (login first)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// MVC route for all other controllers
app.MapControllerRoute(
    name: "mvc",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();