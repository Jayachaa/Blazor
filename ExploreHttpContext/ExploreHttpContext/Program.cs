using ExploreHttpContext;
using ExploreHttpContext.Data;
using ExploreHttpContextCommon;
using Microsoft.AspNetCore.Components.Server.Circuits;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHostedService<HostedService>();

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddSingleton<CircuitHandler, AppCircuitHandler>();

Console.WriteLine("Before build application: time - " + DateTime.Now);
WebApplication app = builder.Build();
Console.WriteLine("After build application: time - " + DateTime.Now);

// Application
app.Lifetime.ApplicationStarted.Register(HttpApplications.Application_Start);
app.Lifetime.ApplicationStopped.Register(HttpApplications.Application_End);

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(
        async (context, next) =>
        {
	        Console.WriteLine("In middleware: time - " + DateTime.Now);
			await next(context);
        });

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();