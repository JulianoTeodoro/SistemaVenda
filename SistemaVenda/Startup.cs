
using Application.Services;
using Application.Services.Interfaces;
using Application.Services.Venda;
using Domain.Entidades;
using Domain.Services;
using Infra;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositorio.DAL;
using Repositorio.Interfaces;
using Repositorio.Repositories;
using SistemaVenda.Helpers;
using SistemaVenda.Models.Profiles;
using System;

namespace SistemaVenda
{
    public class Startup
    {

        public IConfiguration configuration;

        public Startup(IConfiguration config)
        {
            configuration = config;
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }

        public void ConfigureServices(IServiceCollection services) {

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<Criptografia>();
            services.AddInfrascruture(configuration);

            services.AddScoped<IGraficoService, GraficoService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
