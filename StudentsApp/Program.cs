using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentsApp.Infrastructure;
using StudentsApp.Models;
using StudentsApp.Profiles;
using StudentsApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentsDataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddTransient<IStudentRepo, StudentRepo>();

//var mappingconfig = new MapperConfiguration(options =>
//{
//    options.AddProfile(AutoMapperProfile);
//});
//IMapper mapper = mappingconfig.CreateMapper();
//builder.Services.AddSingleton(mapper);
//builder.Services.AddMvc();
//builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
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
