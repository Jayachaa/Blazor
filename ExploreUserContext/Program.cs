using ExploreUserContext.Data;
using ExploreUserContextCommon;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<HttpContextAccessors>();
builder.Services.AddScoped<UserContext>();

WebApplication app = builder.Build();

app.Lifetime.ApplicationStarted.Register(HttpApplications.Application_Start);
app.Lifetime.ApplicationStopped.Register(HttpApplications.Application_End);

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// middleware set context
app.Use(
        async (context, next) =>
        {
            HttpContextAccessors.Current = context;

            await next();
        });

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();