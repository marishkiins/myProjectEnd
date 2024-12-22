
using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddDbContext<SmirnovaPlanGoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<SmirnovaPlanGoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
     b => b.MigrationsAssembly("DataAccess")));

            //var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddDbContext<SmirnovaPlanGoDbContext>(
            //     options => options.UseSqlServer(builder.Configuration["ConnectionString"]));
            ////optionsAction: options => options.UseSqlServer(connectionString: builder.Configuration["ConnectionString"]));
            ////optionsAction: options => options.UseSqlServer(
            ////connectionString: "Server=DESKTOP-0V11DFU;Database=SmirnovaPlanGoDB;Integrated Security=True;TrustServerCertificate=True;"));


 


            // Add services to the container.

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITasksService, TasksService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Интернет-магазин API",
                    Description = "Краткое описание вашего API",
                    Contact = new OpenApiContact
                    {
                        Name = "Пример контакта",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Пример лицензии",
                        Url = new Uri("https://example.com/license")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            //
            builder.WebHost.UseUrls("http://0.0.0.0:5000");
            //

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SmirnovaPlanGoDbContext>();
                context.Database.Migrate();
            }

            //using (var scope = app.Services.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<SmirnovaPlanGoDbContext>();
            //    dbContext.Database.Migrate();
            //}

            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    var context = services.GetRequiredService<SmirnovaPlanGoDbContext>();
            //    context.Database.Migrate();
            //}

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
