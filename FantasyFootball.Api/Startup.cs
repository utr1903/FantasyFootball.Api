using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FantasyFootball.Data;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;
using URF.Core.EF.Trackable;
using FantasyFootball.Entity.Models;
using FantasyFootball.Service.PrimitiveServices.UsersService;
using FantasyFootball.Repositories.UserRepository;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using FantasyFootball.Service.AdvancedServices.UsersService;
using FantasyFootball.Service.AdvancedServices.UsersService.UserAuthenticationHandler;
using FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler;

namespace FantasyFootball.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.User, Policies.UserPolicy());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddHttpContextAccessor();

            services.AddMvc();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            var connectionString = Configuration.GetConnectionString("FantasyFootballConnection");
            services.AddDbContext<FantasyFootballContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<DbContext, FantasyFootballContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories

            // User
            services.AddScoped<ITrackableRepository<User>, TrackableRepository<User>>();
            services.AddScoped<IUsersRepository<User>, UsersRepository<User>>();

            // Primitive Services

            // UsersServiceP
            services.AddScoped<IUsersServiceP, UsersServiceP>();
            
            // Advanced Services

            // UsersServiceA
            services.AddScoped<IUserAuthenticationHandler, UserAuthenticationHandler>();
            services.AddScoped<IUserSettingsHandler, UserSettingsHandler>();
            services.AddScoped<IUsersServiceA, UsersServiceA>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
