using AutoMapper;
using GenericRepoGenericRepositoryWithAuthenticationsitory.Core.Security.Models;
using GenericRepositoryWithAuthentication.API.Mapping;
using GenericRepositoryWithAuthentication.Core.Repositories;
using GenericRepositoryWithAuthentication.Core.Security.Models;
using GenericRepositoryWithAuthentication.Core.Services;
using GenericRepositoryWithAuthentication.Core.UnitOfWorks;
using GenericRepositoryWithAuthentication.Data;
using GenericRepositoryWithAuthentication.Data.Contexts;
using GenericRepositoryWithAuthentication.Data.Repositories;
using GenericRepositoryWithAuthentication.Service.Services;
using GenericRepositoryWithAuthentication.Service.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GenericRepositoryWithAuthentication.API
{
    public class Startup
    {
        #region variables

        public IConfiguration Configuration { get; }

        #endregion

        #region Startup
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            BaseClass.Configuration = configuration;
        }
        #endregion

        #region ConfigureServices
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<NorthwindContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("NorthwindConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenoptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            BaseClass.tokenOptions = tokenoptions;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(j =>
            {
                j.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenoptions.Issuer,
                    ValidAudience = tokenoptions.Audience,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = SignHandler.GetSecurityKey(tokenoptions.SecurityKey)
                };

            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

                //opts.AddPolicy("MyPolicy", builder =>
                //{
                //    builder.WithOrigins("https://www.abc.com").AllowAnyHeader().AllowAnyMethod();
                //    builder.WithOrigins("https://www.xyz.com").AllowAnyHeader().AllowAnyMethod();
                //});

            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MemberJWTDemo", Version = "v1" });
            //});

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            //services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc(op => op.EnableEndpointRouting = false);//.AddNewtonsoftJson();

            services.AddControllers();
        }
        #endregion

        #region Configure
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            //
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseAuthentication();
            //app.UseCors();
            //app.UseMvc();
        }
        #endregion

    }
}
