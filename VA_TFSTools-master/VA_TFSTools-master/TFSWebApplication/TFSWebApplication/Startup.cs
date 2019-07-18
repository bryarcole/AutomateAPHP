using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using TFSWebApplication.Repository.TestCaseResultRepo;
using TFSWebApplication.Repository.TestCaseRepo;
using TFSWebApplication.Repository.TestRunRepo;
using TFSWebApplication.Repository.TestSuiteRepo;
using TFSWebApplication.Repository.ContractRequirementRepo;
using TFSWebApplication.Repository.TestScenarioRepo;
using TFSWebApplication.Repository.MectRequirementRepo;
using TFSWebApplication.Repository.ContractRequirementMectRequirementMapRepo;
using TFSWebApplication.Repository.DefectRepo;
using TFSCommon.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TFSWebApplication
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

            services.Configure<Properties>(Configuration.GetSection("Properties"));

            string connectionString = Configuration.GetConnectionString("Default");
            services.AddTransient<ITestCaseResultRepository>(x => new TestCaseResultRepository(connectionString));
            services.AddTransient<ITestCaseRepository>(x => new TestCaseRepository(connectionString));
            services.AddTransient<ITestRunRepository>(x => new TestRunRepository(connectionString));
            services.AddTransient<ITestSuiteRepository>(x => new TestSuiteRepository(connectionString));
            services.AddTransient<IContractRequirementRepository>(x => new ContractRequirementRepository(connectionString));
            services.AddTransient<IMectRequirementRepository>(x => new MectRequirementRepository(connectionString));
            services.AddTransient<ITestScenarioRepository>(x => new TestScenarioRepository(connectionString));
            services.AddTransient<IContractRequirementMectRequirementMapRepository>(x => new ContractRequirementMectRequirementMapRepository(connectionString));
            services.AddTransient<IDefectRepository>(x => new DefectRepository(connectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TFS External DB",
                    Description = "External DB Connection for TFS Reporting"
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey,
                //    In = ParameterLocation.Header,
                //    BearerFormat = "JWT",
                //    Scheme = "bearer"
                //});

                //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        Implicit = new OpenApiOAuthFlow
                //        {
                //            AuthorizationUrl = new Uri("http://localhost:5000/connect/authorize", UriKind.RelativeOrAbsolute),
                //            Scopes = new Dictionary<string, string>
                //            {
                //                { "openid", "Access read operations" },
                //            }
                //        }
                //    }
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "bearer" }
                //        }, new List<string>()
                //    }
                //});

                //c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.Audience = "api1";
                    options.RequireHttpsMetadata = false;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TFS External DB");

                //c.OAuth2RedirectUrl("https://localhost:44369/swagger/oauth2-redirect.html");

                //c.OAuthClientId("testclient");
                //c.OAuthAppName("testclient");
            });
        }
    }
}
