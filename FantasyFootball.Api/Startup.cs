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
using FantasyFootball.Repositories.FormationRepository;
using FantasyFootball.Repositories.MatchWeekRepository;
using FantasyFootball.Repositories.PlayerHistoryRepository;
using FantasyFootball.Repositories.SeasonRepository;
using FantasyFootball.Repositories.SocialLeagueMemberRepository;
using FantasyFootball.Repositories.SocialLeagueRepository;
using FantasyFootball.Repositories.UserTeamPlayerRepository;
using FantasyFootball.Repositories.UserTeamRepository;
using FantasyFootball.Service.PrimitiveServices.FormationServiceP;
using FantasyFootball.Service.PrimitiveServices.MatchWeekServiceP;
using FantasyFootball.Service.PrimitiveServices.PlayerHistoryServiceP;
using FantasyFootball.Service.PrimitiveServices.SeasonServiceP;
using FantasyFootball.Service.PrimitiveServices.SocialLeagueMemberServiceP;
using FantasyFootball.Service.PrimitiveServices.SocialLeagueServiceP;
using FantasyFootball.Service.PrimitiveServices.UserTeamPlayerServiceP;
using FantasyFootball.Service.PrimitiveServices.UserTeamServiceP;

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

            // Formation
            services.AddScoped<ITrackableRepository<Formation>, TrackableRepository<Formation>>();
            services.AddScoped<IFormationRepository<Formation>, FormationRepository<Formation>>();

            // Language
            services.AddScoped<ITrackableRepository<Language>, TrackableRepository<Language>>();
            services.AddScoped<ILanguageRepository<Language>, LanguageRepository<Language>>();

            // League
            services.AddScoped<ITrackableRepository<League>, TrackableRepository<League>>();
            services.AddScoped<ILeagueRepository<League>, LeagueRepository<League>>();

            // MatchWeek
            services.AddScoped<ITrackableRepository<MatchWeek>, TrackableRepository<MatchWeek>>();
            services.AddScoped<IMatchWeekRepository<MatchWeek>, MatchWeekRepository<MatchWeek>>();

            // PlayerHistory
            services.AddScoped<ITrackableRepository<PlayerHistory>, TrackableRepository<PlayerHistory>>();
            services.AddScoped<IPlayerHistoryRepository<PlayerHistory>, PlayerHistoryRepository<PlayerHistory>>();

            // Player
            services.AddScoped<ITrackableRepository<Player>, TrackableRepository<Player>>();
            services.AddScoped<IPlayerRepository<Player>, PlayerRepository<Player>>();

            // Position
            services.AddScoped<ITrackableRepository<Position>, TrackableRepository<Position>>();
            services.AddScoped<IPositionRepository<Position>, PositionRepository<Position>>();

            // Season
            services.AddScoped<ITrackableRepository<Season>, TrackableRepository<Season>>();
            services.AddScoped<ISeasonRepository<Season>, SeasonRepository<Season>>();

            // SocialLeagueMember
            services.AddScoped<ITrackableRepository<SocialLeagueMember>, TrackableRepository<SocialLeagueMember>>();
            services.AddScoped<ISocialLeagueMemberRepository<SocialLeagueMember>, SocialLeagueMemberRepository<SocialLeagueMember>>();

            // SocialLeague
            services.AddScoped<ITrackableRepository<SocialLeague>, TrackableRepository<SocialLeague>>();
            services.AddScoped<ISocialLeagueRepository<SocialLeague>, SocialLeagueRepository<SocialLeague>>();

            // User
            services.AddScoped<ITrackableRepository<User>, TrackableRepository<User>>();
            services.AddScoped<IUserRepository<User>, UserRepository<User>>();

            // UserTeamPlayer
            services.AddScoped<ITrackableRepository<UserTeamPlayer>, TrackableRepository<UserTeamPlayer>>();
            services.AddScoped<IUserTeamPlayerRepository<UserTeamPlayer>, UserTeamPlayerRepository<UserTeamPlayer>>();

            // UserTeam
            services.AddScoped<ITrackableRepository<UserTeam>, TrackableRepository<UserTeam>>();
            services.AddScoped<IUserTeamRepository<UserTeam>, UserTeamRepository<UserTeam>>();

            #endregion Repositories

            #region PrimitiveServices

            // Club
            services.AddScoped<IClubServiceP, ClubServiceP>();

            // Country
            services.AddScoped<ICountryServiceP, CountryServiceP>();

            // Formation
            services.AddScoped<IFormationServiceP, FormationServiceP>();

            // Language
            services.AddScoped<ILanguageServiceP, LanguageServiceP>();

            // League
            services.AddScoped<ILeagueServiceP, LeagueServiceP>();

            // MatchWeek
            services.AddScoped<IMatchWeekServiceP, MatchWeekServiceP>();

            // PlayerHistory
            services.AddScoped<IPlayerHistoryServiceP, PlayerHistoryServiceP>();

            // Player
            services.AddScoped<IPlayerServiceP, PlayerServiceP>();

            // Position
            services.AddScoped<IPositionServiceP, PositionServiceP>();

            // Season
            services.AddScoped<ISeasonServiceP, SeasonServiceP>();

            // SocialLeagueMember
            services.AddScoped<ISocialLeagueMemberServiceP, SocialLeagueMemberServiceP>();

            // SocialLeague
            services.AddScoped<ISocialLeagueServiceP, SocialLeagueServiceP>();

            // User
            services.AddScoped<IUserServiceP, UserServiceP>();

            // UserTeamPlayer
            services.AddScoped<IUserTeamPlayerServiceP, UserTeamPlayerServiceP>();

            // UserTeam
            services.AddScoped<IUserTeamServiceP, UserTeamServiceP>();

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
