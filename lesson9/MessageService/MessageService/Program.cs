using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MessageService.Data;
using MessageService.Messages;
using Quartz;
using Quartz.Spi;
using MessageService.Job;
using Quartz.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessageServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MessageServiceContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGate, Gate>();
builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddSingleton<SendJob>();

string cronstring = builder.Configuration.GetValue<string>("CronString");
builder.Services.AddSingleton(new JobSchedule(jobType: typeof(SendJob), cronExpression: cronstring));
builder.Services.AddSingleton<QuartzHostedService>();
builder.Services.AddHostedService<QuartzHostedService>(provider => provider.GetService<QuartzHostedService>());

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
