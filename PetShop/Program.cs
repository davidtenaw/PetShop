using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PetShop.Data;
using PetShop.Models;
using PetShop.Repository;
using PetShop.Services;

internal class Program
{
    /// <summary>
    /// ///////////////////mlmlm
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        //string UsersConnectionString = builder.Configuration["ConnectionStrings:DefaultConnection"] ??
        //    "Server=(localdb)\\AspNetCoreCourseUsers;Database=UsersPetShop;Trusted_Connection=True;";

        //string secconnectionString = builder.Configuration["ConnectionStrings:DefaultConnection"] ??
        //    "Server=(localdb)\\AspNetCoreCourse;Database=PetShop;Trusted_Connection=True;";
        builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnection")));
        builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UsersConnection")));


        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>();
        builder.Services.AddScoped<Service>();
        builder.Services.AddScoped<FileService>();
        builder.Services.AddScoped<IdentityService>();



        builder.Services.AddScoped<IRepository<Animal>, AnimalRepository>();
        builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
        builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
        //builder.Services.AddScoped<IRepository<User>, UserRepository>();






        var app = builder.Build();
        app.UseStaticFiles();

        using (var scope = app.Services.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<ShopContext>();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var ctxIdentity = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
            ctxIdentity.Database.EnsureDeleted();
            ctxIdentity.Database.EnsureCreated();

            var identity = scope.ServiceProvider.GetRequiredService<IdentityService>();
          _=  identity.RoleManager.CreateAsync(new IdentityRole { Name = "Admin" }).Result;

            var u = new IdentityUser { UserName = "Admin" };
            _ = identity.UserManager.CreateAsync(u, "Admin123!").Result;
            _ = identity.UserManager.AddToRoleAsync(u, "Admin").Result;


        }
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllerRoute("Default", "{controller=Home}/{action=Index}");

        app.Run();


    }


    //using (var scope = app.Services.CreateScope())
    //{


    //    var ctxIdentity = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    //    ctxIdentity.Database.EnsureDeleted();
    //    ctxIdentity.Database.EnsureCreated();

    //}   
}
