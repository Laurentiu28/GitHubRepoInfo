using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GitHubRepoInfo.Repositories;

namespace GitHubRepoInfo
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                });
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Entities.Repository, DTO.UserRepositoryDto>()
                        .ForMember(x => x.Commits, x => x.MapFrom(z => z.Commits));
                config.CreateMap<Entities.Commit, DTO.CommitDto>()
                        .ForMember(x => x.Name, x => x.MapFrom(z => z.Committer.Name))
                        .ForMember(x => x.Date, x => x.MapFrom(z => z.Committer.Date))
                        .ForMember(x => x.SHA, x => x.MapFrom(z => z.Tree.Sha));

            });

            app.UseMvc();
        }
    }
}
