using SingleRepositoryArch.Infra.Data;
using Microsoft.EntityFrameworkCore;
using SingleRepositoryArch.Core.Interfaces.Management;
using SingleRepositoryArch.Core.Interfaces.Base;
using SingleRepositoryArch.Core.ApplicationServices.Base;
using SingleRepositoryArch.Core.ApplicationServices.Management;
using SingleRepositoryArch.Core.Repositories;

namespace SingleRepositoryArch.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(option => option.EnableEndpointRouting = false);
            services.AddDbContext<SingleRepoContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("SingleRepoArchConnectionString"));
            });
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ITeacherDetailsService, TeacherDetailsService>();
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<ISemesterScheduleService, SemesterScheduleService>();
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvc((route) =>
            {
                route.MapRoute("default", "{Controller=Teacher}/{Action=Index}");
            });
        }
    }
}
