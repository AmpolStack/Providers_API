
using Providers_API.IOC;
using Providers_API.Utilities.AutoMapping;

namespace Providers_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAllPolicity", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            builder.Services.InjectionDependencies(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAllPolicity");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
