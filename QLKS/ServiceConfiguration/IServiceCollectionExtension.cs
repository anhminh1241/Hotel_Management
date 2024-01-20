using AutoMapper;
using HotelManagement.MapperProfile;
using HotelManagement.Repositories.Interfaces;
using HotelManagement.Repositories;
using HotelManagement.Services.Impls;
using HotelManagement.Services;
using Microsoft.OpenApi.Models;

namespace HotelManagement.ServiceConfiguration
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepo<,>), typeof(BaseRepo<,>));
            services.AddTransient<IRoomRepo, RoomRepo>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoomTypeRepo, RoomTypeRepo>();
            services.AddTransient<IBookingRepo, BookingRepo>();
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
        public static IServiceCollection AddMapperServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Project API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });

            return services;
        }

    }
}
