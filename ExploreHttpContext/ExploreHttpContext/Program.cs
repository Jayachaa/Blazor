using ExploreHttpContext;
using ExploreHttpContext.Data;
using ExploreHttpContextCommon;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<IHttpContextAccessorCommon, HttpContextAccessorCommon>();
builder.Services.AddScoped<UserContext>();

WebApplication app = builder.Build();



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




app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();



app.UseRouting();

//app.Use(async (context, next) =>
//		{
//			//HttpContextAccessorCommon.Current = context;
//			await next();
//		});

// HttpContext
//app.UseHttpContextMiddleware();

// Use extension with RequestServices
app.Use(
        async (context, next) =>
        {
            {
                var httpContextAccessorCommon = context.RequestServices.GetService<IHttpContextAccessorCommon>();
                if(httpContextAccessorCommon != null) httpContextAccessorCommon.Current = context;
            }

            await next();
        });


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

