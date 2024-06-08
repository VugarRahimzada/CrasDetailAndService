using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.Concrete;
using BusinessLayer.Mapper;
using BusinessLayer.Validation.FluentValidations;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Membership;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinalProjectVRAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(DTOMapper));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(DTOMapper).Assembly);
            });
            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddScoped<IBlogService, BlogManager>();
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();

            // Register FluentValidation validators
            builder.Services.AddValidatorsFromAssemblyContaining<BlogValidation>();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>()
                           .AddIdentity<ApplicationUser, ApplicationRole>()
                           .AddEntityFrameworkStores<AppDbContext>();

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
