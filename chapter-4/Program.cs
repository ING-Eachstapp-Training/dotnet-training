
using chapter_4.BL;
using chapter_4.DAL;
using chapter_4.Data.Context;
using chapter_4.Middleware;

namespace chapter_4;

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

        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddScoped<UnitOfWork>();
        builder.Services.AddScoped(typeof(TasksBL));
        builder.Services.AddScoped(typeof(UsersBL));

        var app = builder.Build();


        app.UseSwagger();
        app.UseSwaggerUI();


        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseMiddleware<AuthenticationMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

