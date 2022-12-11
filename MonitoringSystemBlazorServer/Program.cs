using MonitoringSystemBlazorServer.Services;

// Initialize application container
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Add Animal Service to container
builder.Services.AddHttpClient<IAnimalService, AnimalService>(client => client.BaseAddress = new Uri("https://localhost:7228/"));
// Add Habitat Service to container
builder.Services.AddHttpClient<IHabitatService, HabitatService>(client => client.BaseAddress = new Uri("https://localhost:7228/"));

// Build application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

