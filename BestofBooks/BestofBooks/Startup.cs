using BestofBooks.Repo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BestofBooks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // ── MVC ──────────────────────────────────────────────────────
            services.AddControllersWithViews(options =>
            {
                // Global anti-forgery validation on all POST endpoints.
                // Protects every form in the app from CSRF without needing
                // [ValidateAntiForgeryToken] on each individual action.
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute());
            });

            // ── Cookie authentication ─────────────────────────────────────
            // Replaces the hand-rolled session-based auth. The browser holds
            // an encrypted cookie; ASP.NET Core validates it on every request.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Index";   // redirect here if not logged in
                    options.AccessDeniedPath = "/Home/Error";   // redirect here if not authorized
                    options.ExpireTimeSpan = TimeSpan.FromHours(8);
                    options.SlidingExpiration = true;           // reset timer on activity
                    options.Cookie.HttpOnly = true;            // not readable by JS — XSS protection
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Strict;
                });

            // ── Authorization policies ────────────────────────────────────
            // Named policies map to your existing user permission flags.
            // Use [Authorize(Policy = "RequireAdmin")] on controller actions.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireLogin", policy =>
                    policy.RequireAuthenticatedUser());

                options.AddPolicy("RequireAdmin", policy =>
                    policy.RequireAuthenticatedUser()
                          .RequireClaim("is_Admin", "true"));

                options.AddPolicy("RequireEdits", policy =>
                    policy.RequireAuthenticatedUser()
                          .RequireClaim("edits_enabled", "true"));

                options.AddPolicy("RequireAdds", policy =>
                    policy.RequireAuthenticatedUser()
                          .RequireClaim("adds_enabled", "true"));
            });

            // ── Repositories (Transient is correct for DB-per-request work) ──
            services.AddTransient<IBookRepo, BookRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IAuditRepo, AuditRepo>();

            // ── Session (keep for non-auth UI state if needed, e.g. search state) ──
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;  // GDPR — session works without consent
            });

            // ── Response compression (speeds up HTML/CSS/JSON over the wire) ──
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ── Error handling ────────────────────────────────────────────
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();  // Default 30-day HSTS; fine for production
            }

            // ── Pipeline order matters — do not rearrange ─────────────────
            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();    // ← was missing entirely
            app.UseAuthorization();     // must come AFTER UseAuthentication

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=InventoryList}/{id?}");
            });
        }
    }
}