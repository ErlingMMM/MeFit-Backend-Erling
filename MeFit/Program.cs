using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using MeFit.Services.Exercises;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MeFit.Services.Workouts;
using MeFit.Services.Plans;

namespace MeFit.Data
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MeFit API",
                    Description = "API for workouts, exercises and plans",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Erling",
                        Url = new Uri("https://example.com/contact")
                    }
                });
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });


            builder.Services.AddDbContext<MeFitDdContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            // Add our service
            builder.Services.AddScoped<IExercisesService, ExerciseService>();
            builder.Services.AddScoped<IWorkoutService, WorkoutService>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            // Add automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(typeof(ExerciseService));
            builder.Services.AddAutoMapper(typeof(WorkoutService));
            builder.Services.AddAutoMapper(typeof(PlanService));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(options =>
                {
                    options.SerializeAsV2 = true;
                }
                );
                app.UseSwaggerUI(options =>
                {
                    app.UseSwaggerUI(c =>
                    {
                        c.RoutePrefix = "swagger";
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    });
                });
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
