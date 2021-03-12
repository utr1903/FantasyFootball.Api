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
using FantasyFootball.Repositories.UserRepository;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using FantasyFootball.Service.AdvancedServices.UsersService;
using FantasyFootball.Service.AdvancedServices.UsersService.UserAuthenticationHandler;
using FantasyFootball.Service.AdvancedServices.UsersService.UserSettingsHandler;
using FantasyFootball.Common.AuthChecker;
using FantasyFootball.Repositories.ClubRepository;
using FantasyFootball.Repositories.CountryRepository;
using FantasyFootball.Repositories.LanguageRepository;
using FantasyFootball.Repositories.LeagueRepository;
using FantasyFootball.Repositories.PlayerRepository;
using FantasyFootball.Repositories.PositionRepository;
using FantasyFootball.Service.PrimitiveServices.UserServiceP;
using FantasyFootball.Service.PrimitiveServices.ClubServiceP;
using FantasyFootball.Service.PrimitiveServices.CountryServiceP;
using FantasyFootball.Service.PrimitiveServices.LanguageServiceP;
using FantasyFootball.Service.PrimitiveServices.LeagueServiceP;
using FantasyFootball.Service.PrimitiveServices.PlayerServiceP;
using FantasyFootball.Service.PrimitiveServices.PositionServiceP;

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

            #region Repositories

            // Clubs
            services.AddScoped<ITrackableRepository<Club>, TrackableRepository<Club>>();
            services.AddScoped<IClubRepository<Club>, ClubRepository<Club>>();

            // Country
            services.AddScoped<ITrackableRepository<Country>, TrackableRepository<Country>>();
            services.AddScoped<ICountryRepository<Country>, CountryRepository<Country>>();

            // Language
            services.AddScoped<ITrackableRepository<Language>, TrackableRepository<Language>>();
            services.AddScoped<ILanguageRepository<Language>, LanguageRepository<Language>>();

            // League
            services.AddScoped<ITrackableRepository<League>, TrackableRepository<League>>();
            services.AddScoped<ILeagueRepository<League>, LeagueRepository<League>>();

            // Player
            services.AddScoped<ITrackableRepository<Player>, TrackableRepository<Player>>();
            services.AddScoped<IPlayerRepository<Player>, PlayerRepository<Player>>();

            // Position
            services.AddScoped<ITrackableRepository<Position>, TrackableRepository<Position>>();
            services.AddScoped<IPositionRepository<Position>, PositionRepository<Position>>();

            // User
            services.AddScoped<ITrackableRepository<User>, TrackableRepository<User>>();
            services.AddScoped<IUserRepository<User>, UserRepository<User>>();

            #endregion Repositories

            #region PrimitiveServices

            // Club
            services.AddScoped<IClubServiceP, ClubServiceP>();

            // Country
            services.AddScoped<ICountryServiceP, CountryServiceP>();

            // Language
            services.AddScoped<ILanguageServiceP, LanguageServiceP>();

            // League
            services.AddScoped<ILeagueServiceP, LeagueServiceP>();

            // Player
            services.AddScoped<IPlayerServiceP, PlayerServiceP>();

            // Position
            services.AddScoped<IPositionServiceP, PositionServiceP>();

            // User
            services.AddScoped<IUserServiceP, UserServiceP>();

            #endregion PrimitiveServices

            #region Common

            services.AddScoped<IAuthChecker, AuthChecker>();

            #endregion Common

            #region AdvancedServices

            // Users
            services.AddScoped<IUserAuthenticationHandler, UserAuthenticationHandler>();
            services.AddScoped<IUserSettingsHandler, UserSettingsHandler>();
            services.AddScoped<IUsersServiceA, UsersServiceA>();

            #endregion AdvancedServices
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
