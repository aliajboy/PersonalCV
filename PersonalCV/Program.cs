using PersonalCV.Data.Interfaces;
using PersonalCV.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => options.Conventions.AuthorizeFolder("/Admin"));

builder.Services.AddTransient<IContactMessage>(x => new ContactMessageRepository(builder.Configuration.GetConnectionString("sqlserver")));

builder.Services.AddDbContext<PersonalCVContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PersonalCVContext>();
builder.Services.AddResponseCompression();

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
app.UseResponseCompression();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<PersonalCVContext>();
    context?.Database.EnsureCreated();
}

await app.RunAsync();