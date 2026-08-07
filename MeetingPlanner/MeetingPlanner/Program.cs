using MeetingPlanner.Classes;
using MeetingPlanner.Components;
using MeetingPlanner.Services;
using MeetingPlanner.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<MeetingsService>();
builder.Services.AddScoped<ProjectsService>();

builder.Services.AddScoped<MeetingStateService>();
builder.Services.AddScoped<IMeetingService, MockMeetingService>();

// -----------------------------------------------------------------------------------
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>(); 
builder.Services.AddScoped<InMemoryAuthService>();
builder.Services.AddScoped<CustomAuthStateProvider>();

builder.Services.AddAuthorization(); 
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>()); 

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "CustomAuthentication";
    options.DefaultChallengeScheme = "CustomAuthentication";
});
// -----------------------------------------------------------------------------------

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

app.Run();
