using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using WebTodo.Components;
using WebTodo.Provider;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

{
    builder.Services.AddRadzenComponents();
    builder.Services.AddBlazoredLocalStorage();
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5237") });
    builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
    builder.Services.AddCascadingAuthenticationState();
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
