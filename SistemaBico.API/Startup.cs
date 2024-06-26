using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sistema.Bico.Domain.AutoMapper;
using Sistema.Bico.Domain.Generics.Entities;
using Sistema.Bico.Infra.Context;
using SistemaBico.API.Configurations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.API
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

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
                options.SupportedCultures = new[] { new CultureInfo("pt-BR") };
                options.SupportedUICultures = new[] { new CultureInfo("pt-BR") };
            });


            services.AddDbContext<ContextBase>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Sistema.Bico.Infra")));

			services.AddDefaultIdentity<ApplicationUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.SignIn.RequireConfirmedPhoneNumber = false;

				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 0;

			}).AddEntityFrameworkStores<ContextBase>();

			// Repositorys
			services.AddInjectRepositorys();

			// Commands
			services.AddInjectHandlers();

			services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
			services.AddAutoMapper(typeof(AutoMapperInterface).Assembly);

			// Notification
			services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

			services.AddControllers()
				.AddNewtonsoftJson(s =>
				{
					s.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
				}).AddFluentValidation();

			services.AddInjectValidation();

			services.AddControllersWithViews();
			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.ReportApiVersions = true;
				options.AssumeDefaultVersionWhenUnspecified = true;
			});

			services.AddVersionedApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
			  {
				{
				  new OpenApiSecurityScheme
				  {
					Reference = new OpenApiReference
					  {
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					  },
					  Scheme = "oauth2",
					  Name = "Bearer",
					  In = ParameterLocation.Header,

					},
					new List<string>()
				  }
				});
			});

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options =>
			{
				options.LoginPath = new PathString("/Login"); //401 - Unauthorized
				options.AccessDeniedPath = new PathString("/Login"); //403 - Forbidden
			});


			services.AddSwaggerGenNewtonsoftSupport();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
            app.UseRequestLocalization();

            if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});

			app.UseSwaggerESwaggerUI();
		}
	}
}
