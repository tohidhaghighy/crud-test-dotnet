using Microsoft.AspNetCore.ResponseCompression;
using Mc2.CrudTest.Infrastructure.Data;
using System;
using Microsoft.EntityFrameworkCore;
using Carter;
using Mc2.CrudTest.Presentation.Server;
using Microsoft.AspNetCore.Builder;
using Mc2.CrudTest.Domain.Interfaces.Customer;
using Mc2.CrudTest.Services.Services;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddCarter();
            builder.Services.AddEndpointsApiExplorer(); 
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllersWithViews();
            // Add services to the container.
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<CustomerDbContext>(options =>options.UseSqlServer(connectionString));
            builder.Services.AddScoped<ICustomerService, CustomerService>();

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

            app.UseRouting();
            app.MapControllers();
            app.MapCarter();

            app.Run();
        }
    }
}