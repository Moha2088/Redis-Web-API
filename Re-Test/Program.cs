using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Re_Test.Data;
using Re_Test.Services;
using StackExchange.Redis;

namespace Re_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Re_TestContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Re_TestContext") ?? throw new InvalidOperationException("Connection string 'Re_TestContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddScoped<ICacheService, CacheService>();
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

            app.UseAuthorization();


           
            app.MapControllers();

            app.Run();
        }
    }
}
