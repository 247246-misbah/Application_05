using Application_05.Components;
using Application_05.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. REGISTER CORE INTERACTIVE SERVICES
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register State Management Service as a Singleton
builder.Services.AddSingleton<AuthenticationStateService>();

var app = builder.Build();

// 2. CONFIGURE PIPELINE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Modern Blazor Web App Routing (No _Host fallback crash!)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();