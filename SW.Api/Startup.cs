using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using SW.Infrastructure.Filters;
using SW.Infrastructure.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using SW.Application.Mapping;
using SW.Common.Interfaces.Repositories;
using SW.Infrastructure;
using SW.Infrastructure.Repositories;
using SW.Common.Interfaces.Services;
using SW.Application.Services;
using SW.Domain.Interfaces;
using SW.Common.Helpers;
// using SW.Domain.Interfaces.Repositories;
using SW.Domain.Interfaces.Services;
// using SW.application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace SW.Api;

public class Startup
{
    private readonly IConfiguration _configuration;
    private TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");

    public Startup(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public IConfiguration Configuration => _configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(
            options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            }
        )
            .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.WriteIndented = true;
        });

        // Add swagger
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "AW Project API", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlFilePath);

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
        });

        services.AddEndpointsApiExplorer();

        // Add DB Connection string
        services.AddDbContext<SWDbContext>(options =>

            options.UseSqlServer(Configuration.GetConnectionString("swDevString") ?? throw new InvalidOperationException("Database Connection String Not Found...")).UseLazyLoadingProxies()
        );

        // Add Mappers
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        // Add Authorizacion
        services.AddAuthorization(options =>
        {
            
        });

        // Configure Cors
        services.AddCors(options => options.AddPolicy("corsPolicy", builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        }));

        // Add Repositories
        services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
        services.AddScoped(typeof(IRetrieveRepository<>), typeof(RetrieveRepository<>));
        services.AddScoped(typeof(ICatalogBaseRepository<>), typeof(CatalogBaseRepository<>));
        services.AddScoped<ILocalStorageRepository, LocalStorageRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // services.AddScoped<IUserAccountRepository, UserAccountRepository>();

        // Add Serivces
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        services.AddScoped(typeof(ICatalogBaseService<>), typeof(CatalogBaseService<>));
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IMiscellaneousService, MiscellaneousService>();
        services.AddScoped<ILocalStorageService, LocalStorageService>();
        // services.AddScoped<IUserAccountService, UserAccountService>();
        services.AddScoped<ITokenHelperService, TokenHelper>();
        services.AddHttpContextAccessor();

        // Add AutoValidator
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        // Add Cashing
        services.AddResponseCaching();

        // Add JWT
        services.AddAuthentication(opttions =>
        {
            opttions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opttions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Authentication:Issuer"],
                ValidAudience = Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]!))
            };
        });

        // Add
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("es-MX");
            options.SupportedCultures = new List<CultureInfo> { new CultureInfo("es-MX") };
            options.RequestCultureProviders.Clear();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        //app.UseLogResponseHttp();

        app.UseCors("corsPolicy");

        app.UseHttpsRedirection();

        // Configure the HTTP request pipeline.
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStaticFiles();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "AW Project API V1");
            options.RoutePrefix = string.Empty;
        });

        app.UseRouting();

        app.UseResponseCaching();

        //app.UseRequestLocalization();
        // app.UseRequestLocalization(new RequestLocalizationOptions
        // {
        //     DefaultRequestCulture = new RequestCulture("es-MX"),
        //     SupportedCultures = new List<CultureInfo>
        //     {
        //         new CultureInfo("es-MX"),
        //     },
        //     SupportedUICultures = new List<CultureInfo>
        //     {
        //         new CultureInfo("es-MX"),
        //     },
        //     RequestCultureProviders = new List<IRequestCultureProvider>
        //     {
        //         new QueryStringRequestCultureProvider(),
        //         new CookieRequestCultureProvider(),
        //         new AcceptLanguageHeaderRequestCultureProvider(),
        //     },
        // });

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}