using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DDDSample1.Infrastructure;
using DDDSample1.Infrastructure.Orders;
using DDDSample1.Infrastructure.Warehouses;
using DDDSample1.Infrastructure.Deliveries;
using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Orders;
using DDDSample1.Domain.Warehouses;
using DDDSample1.Domain.Deliveries;
using MySqlConnector;

namespace DDDSample1
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
    
            
            services.AddDbContext<DDDSample1DbContext>(opt =>

                opt.UseMySql(Configuration.GetConnectionString("DbLapr5G016"),
                        new MySqlServerVersion(new System.Version(10, 6, 8)))
                    .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>().EnableDetailedErrors()
            );

            // Adding Authentication  
            // services.AddAuthentication(options =>
            // {
            //     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            // })

            // // Adding Jwt Bearer  
            // .AddJwtBearer(options =>
            // {
            //     options.SaveToken = true;
            //     options.RequireHttpsMetadata = false;
            //     options.TokenValidationParameters = new TokenValidationParameters()
            //     {
            //         ValidateIssuer = true,
            //         ValidateAudience = true,
            //         ValidAudience = Configuration["JWT:ValidAudience"],
            //         ValidIssuer = Configuration["JWT:ValidIssuer"],
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
            //     };
            // });

            services.AddCors(options =>
             { 
                options.AddPolicy("AllowAll", builder => 
                {
                     builder
                     .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader().Build(); 
                }); 
            });
            ConfigureMyServices(services);

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();
        }

        public void ConfigureMyServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork,UnitOfWork>();

            services.AddTransient<IOrderRepository,OrderRepository>();
            services.AddTransient<OrderService>();

            services.AddTransient<IWarehouseRepository,WarehouseRepository>();
            services.AddTransient<WarehouseService>();

            services.AddTransient<IDeliveryRepository,DeliveryRepository>();
            services.AddTransient<DeliveryService>();

        }
    }
}
