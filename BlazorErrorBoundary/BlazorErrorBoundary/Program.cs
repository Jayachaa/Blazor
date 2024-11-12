using System.Text;
using BlazorErrorBoundary.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<HtmlRendererService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
public class HtmlRendererService
{
    public async Task<string> RenderFragmentToStringAsync(RenderFragment renderFragment)
    {
        using var stringWriter = new StringWriter();
        var builder = new RenderTreeBuilder();

        // Render the fragment
        renderFragment(builder);

        // Convert builder content to a string (this step requires advanced rendering handling)
        var renderedContent = new StringBuilder();

        // Simulate appending content (in reality, you may need to handle this with custom logic)
        // This part might involve integration with Blazor internals or low-level rendering APIs

        return renderedContent.ToString();
    }
}