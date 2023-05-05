using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using TradeCaptureWebAPI;
using TradeCaptureWebAPI.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson(x =>
        {
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });


        builder.Services
            .AddDbContext<TradeCaptureContext>(opt =>
            //opt.UseInMemoryDatabase("TradeCaptureList"));
            opt.UseSqlServer(builder.Configuration.GetConnectionString("TradeCapture")));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //cors
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; 
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              policy =>
                              {
                                  policy.WithOrigins("http://localhost:4200")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                              });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        

        app.UseHttpsRedirection();
        app.UseRouting(); //

        app.UseCors(MyAllowSpecificOrigins);//

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}