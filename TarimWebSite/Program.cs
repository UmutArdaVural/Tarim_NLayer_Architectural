using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using DataAccessLayer.Absract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IServicesService, ServiceManager>();
builder.Services.AddScoped<IServicesDal, EfServicesDal>();

builder.Services.AddScoped<ITeamsService, TeamManager>();
builder.Services.AddScoped<ITeamsDal, EfTeamsDal>();

builder.Services.AddScoped<IAnnouncementsService, AnnouncementsManager>();
builder.Services.AddScoped<IAnnouncementsDal, EfAnnouncementsDal>();

builder.Services.AddDbContext<TarimWebSiteContext>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
