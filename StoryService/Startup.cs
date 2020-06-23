using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBroker;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StoryService.MessageHandlers;
using StoryService.MqMessages;
using StoryService.Repositories;
using StoryService.Services;
using StoryService.Settings;

namespace StoryService
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
            services.AddCors();
            #region jwt
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                };
            });
            #endregion
            #region mq
            services.Configure<MessagequeueSettings>(Configuration.GetSection("MessageQueueSettings"));
            services.AddMessageConsumer(Configuration["MessageQueueSettings:Uri"],
                "verhaal-service",
                builder => builder.WithHandler<WorldMessagehandler>("new-world").WithHandler<WorldDeleteMessageHandler>("delete-world"));
            #endregion
            #region db injection
            services.Configure<StoryServiceDatastoreSettings>(
               Configuration.GetSection("StorystoreDatabaseSettings"));

            services.AddSingleton<IStoryServiceDatastoreSettings>(sp =>
                sp.GetRequiredService<IOptions<StoryServiceDatastoreSettings>>().Value);
            #endregion
            #region services
            services.AddTransient<IStoryService, StoryService.Services.StoryService>();
            services.AddTransient<IPageService, StoryService.Services.PageService>();
            services.AddTransient<IWorldEditService, WorldEditService>();
            #endregion
            #region
            services.AddTransient<IWorldRepository, WorldRepository>();
            services.AddTransient<IStoryRepository, StoryRepository>();
            #endregion
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());

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
