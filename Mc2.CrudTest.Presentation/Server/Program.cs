using Microsoft.AspNetCore.ResponseCompression;
using Mc2.CrudTest.Infrastructure.Data;
using System;
using Microsoft.EntityFrameworkCore;
using Carter;
using Mc2.CrudTest.Presentation.Server;
using Microsoft.AspNetCore.Builder;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var appPartsAssemblies = ApplicationPartDiscovery.FindAssemblies();
            builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(appPartsAssemblies));
            builder.Services.AddCarter(new DependencyContextAssemblyCatalog(appPartsAssemblies));
            builder.Services.AddSwaggerGen();

            // Add services to the container.
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<CustomerDbContext>(options =>options.UseSqlServer(connectionString));
            

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}