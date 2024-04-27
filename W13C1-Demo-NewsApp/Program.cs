// Create a new web application builder with the provided command-line arguments
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This includes services for controllers and views, which are required for MVC.
builder.Services.AddControllersWithViews();

// Add CORS (Cross-Origin Resource Sharing) services to the container.
// This allows the app to accept cross-origin requests.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            // Configure the CORS policy to allow requests from a specific origin (http://localhost:5003),
            // and to allow any headers and methods in those requests.
            builder.WithOrigins("http://localhost:5003")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.
// If the app is not in development mode, use the exception handler middleware to handle exceptions.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Use the static files middleware to serve static files.
app.UseStaticFiles();

// Use the routing middleware to route requests.
app.UseRouting();

// Use the CORS middleware with the specified policy.
app.UseCors("AllowSpecificOrigin");

// Use the authorization middleware.
app.UseAuthorization();

// Map a default route for controllers.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application.
app.Run();