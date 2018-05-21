using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StravaClub.Core;
using StravaClub.Core.Domain;
using StravaClub.Core.Infra.Http;
using StravaClub.Core.Infra.Sql;
using StravaClub.Core.Interfaces;
using StravaClub.Core.Interfaces.Domain;
using StravaClub.Core.Interfaces.Http;
using StravaClub.Core.Interfaces.Sql;
using StravaClub.Web.Utils;

namespace StravaClub
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
		
			services.AddSingleton<IAppSettings>(Configuration.GetAppSettings());

			services.AddScoped<IActivityRepository, ActivityRepository>();
			services.AddScoped<IAthleteRepository, AthleteRepository>();
			services.AddScoped<IPhotoRepository, PhotoRepository>();
			services.AddScoped<IStravaParser, StravaParser>();
			services.AddScoped<IStravaRepository, StravaRepository>();
            services.AddScoped<IRank, Rank>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}
