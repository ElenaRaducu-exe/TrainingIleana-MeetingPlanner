using MeetingPlanner.Components;
using MeetingPlanner.Services;
using MeetingPlanner.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;

using MudBlazor.Services;
using MeetingPlanner.Auth;
using MeetingPlanner.Classes;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthenticationCore();
builder.Services.AddAuthorization();

// -----------------------------------------------------------------------------------
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>(); 
builder.Services.AddScoped<InMemoryAuthService>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => 
            provider.GetRequiredService<CustomAuthStateProvider>());

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin")); 
});

/*
builder.Services.Configure<AuthenticationOptions>(options =>
{
    options.DefaultAuthenticateScheme = "CustomAuthentication";
    options.DefaultChallengeScheme = "CustomAuthentication";
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "CustomAuthentication";
    options.DefaultChallengeScheme = "CustomAuthentication";
});*/
// -----------------------------------------------------------------------------------

builder.Services.AddScoped<MeetingsService>();
builder.Services.AddScoped<ProjectsService>();

builder.Services.AddScoped<MeetingStateService>();
builder.Services.AddScoped<IMeetingService, MockMeetingService>();

// register MudBlazor 
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
