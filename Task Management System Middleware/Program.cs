using Microsoft.EntityFrameworkCore;
using Task_Management_System_Middleware.Context;
using Task_Management_System_Middleware.SQLRepository.TaskRepository;
//using Task_Management_System_Middleware.Context;
//using Task_Management_System_Middleware.SQLRepository.TaskRepository;

namespace Task_Management_System_Middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //DB Configurations
            builder.Services.AddDbContext<TaskManagementSystemDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DB_connection_string")));

            //Dependency Injection
            builder.Services.AddScoped<ITaskRepository, SqlTaskRepository>();

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
