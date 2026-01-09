using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Options;
using Peterffy_Dominika_backend.Models;
using Peterffy_Dominika_backend.Models.DTOs;
using Peterffy_Dominika_backend.Services;
using Peterffy_Dominika_backend.Services.Library;
using System.Text.Json.Serialization;

namespace Peterffy_Dominika_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<LibrarydbContext>();
            builder.Services.AddScoped<ResponseDTO>();
            builder.Services.AddScoped<IBook, booksService>();
            builder.Services.AddScoped<IAuthor, authorService>();
            builder.Services.AddScoped<ICategory, categoryService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());});


            // Store the required UID in configuration so controllers can compare against it
            builder.Configuration["UID"] = "FKB3F4FEA09CE43C";

            var app = builder.Build();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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
