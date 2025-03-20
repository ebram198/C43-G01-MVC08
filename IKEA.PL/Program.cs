
using IKEA.BLL.Services;
using IKEA.BLL.Services.Employees;
using IKEA.BLL.Services.Employees;
using IKEA.DAL.presistance.Data;
using IKEA.DAL.presistance.Repository.Departments;
using IKEA.DAL.presistance.Repository.Employees;
using IKEA.DAL.presistance.UniteOfWork;
using IKEA.PL.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IKEA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region configure
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>((OptionsBuilder =>
            {
                
                OptionsBuilder.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }));

            // builder.Services.AddScoped<IDepartmentRepository, DepartmentRepositry>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeReposatory>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeService , EmployeeService>();
            builder.Services.AddAutoMapper(m => m.AddProfile(new MappingProfile()));
            #endregion



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();















        }
    }
}
