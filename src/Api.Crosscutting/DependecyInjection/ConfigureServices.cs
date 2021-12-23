using System;
using System.Text;
using Api.Crosscutting.AutoMapper;
using Api.Service.Interfaces;
using Api.Service.PasswordHasher;
using Api.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Api.Crosscutting.DependecyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServiceDependecies(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITokenService, TokenService>();

            var key = Encoding.ASCII.GetBytes("r75^zh{[]xst*H^T*'j-;\"Ssmvp;`ENLrL-XZ[&X)eUrYS2Um)Zy;b![.1\"e/4d");

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters 
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddTransient<Hasher, Hasher>();

            return services;
        }
    }
}