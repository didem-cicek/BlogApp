using BlogApp.Areas.Admin.Services;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>(d => d.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddControllersWithViews()
    .AddMvcLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");

builder.Services.AddScoped<IFileUploadService, FileUploadService>();

var supportedCulture = new List<CultureInfo>
{
    new CultureInfo("tr-TR"),
    new CultureInfo("en-US"),
};

var defaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR");
builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    opt.DefaultRequestCulture = defaultRequestCulture;
    opt.SupportedCultures = supportedCulture;
    opt.SupportedUICultures = supportedCulture;
});

var app = builder.Build();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = defaultRequestCulture,
    SupportedCultures = supportedCulture,
    SupportedUICultures = supportedCulture
});

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
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
