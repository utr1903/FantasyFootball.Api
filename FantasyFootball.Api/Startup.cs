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
            //services.AddCors();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddMvc();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            var connectionString = Configuration.GetConnectionString("FantasyFootballConnection");
            services.AddDbContext<FantasyFootballContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<DbContext, FantasyFootballContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITrackableRepository<User>, TrackableRepository<User>>();
            services.AddScoped<IUsersRepository<User>, UsersRepository<User>>();
            services.AddScoped<IUsersServiceP, UsersServiceP>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
