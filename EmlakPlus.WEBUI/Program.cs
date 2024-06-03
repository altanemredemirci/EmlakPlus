using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.Concrete;
using EmlakPlus.DAL.Abstract;
using EmlakPlus.DAL.Concrete.EfCore;
using EmlakPlus.WEBUI.Hubs;
using EmlakPlus.WEBUI.Identity;
using EmlakPlus.WEBUI.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddCors(opt =>
    opt.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyHeader()   //Her baþlýða izin ver
           .AllowCredentials() //Kimliklendirmeye izin ver
           .AllowAnyMethod()   //Her metoda izin ver
           .SetIsOriginAllowed((host) => true)
    ));

builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;          //Rakam olsun
    options.Password.RequireNonAlphanumeric = true;//Özel karakter olsun(*,?,-,..)
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);


    options.User.RequireUniqueEmail = true;
    //options.User.AllowedUserNameCharacters = " ";

    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = false;

});



builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".EmlakPlus.Security.Cookie"
    };
});



//Dependency Injection

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfCoreProductDal>();

builder.Services.AddScoped<IProductDetailService, ProductDetailManager>();
builder.Services.AddScoped<IProductDetailDal, EfCoreProductDetailDal>();

builder.Services.AddScoped<IProductTypeService, ProductTypeManager>();
builder.Services.AddScoped<IProductTypeDal, EfCoreProductTypeDal>();

builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<ISliderDal, EfCoreSliderDal>();

builder.Services.AddScoped<IWhoWeAreService, WhoWeAreManager>();
builder.Services.AddScoped<IWhoWeAreDal, EfCoreWhoWeAreDal>();

builder.Services.AddScoped<IAgencyService, AgencyManager>();
builder.Services.AddScoped<IAgencyDal, EfCoreAgencyDal>();

builder.Services.AddScoped<IClientService, ClientManager>();
builder.Services.AddScoped<IClientDal, EfCoreClientDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfCoreContactDal>();

builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<ICityDal, EfCoreCityDal>();

builder.Services.AddScoped<IStatisticService, StatisticManager>();
builder.Services.AddScoped<IStatisticDal, EfCoreStatisticDal>();

builder.Services.AddScoped<IMailService, MailManager>();
builder.Services.AddScoped<IMailDal, EfCoreMailDal>();

builder.Services.AddScoped<ITodoListService, TodoListManager>();
builder.Services.AddScoped<ITodoListDal, EfCoreTodoListDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication(); //Kimliklendirme
app.UseRouting();

app.UseAuthorization(); //Yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");



    app.MapControllerRoute(
    name: "advert",
    pattern: "advert/product",
    defaults: "{area:exists}/{controller=Advert}/{action=Index}/{id?}"
                );

app.MapControllerRoute(
    name: "advert",
    pattern: "advert/expiredProduct",
    defaults: "{area:exists}/{controller=Advert}/{action=ExpiredProduct}/{id?}"
                );

app.MapControllerRoute(
    name: "advert",
    pattern: "advert/Mailbox",
    defaults: "{area:exists}/{controller=Advert}/{action=MailBox}/{id?}"
                );

app.MapControllerRoute(
    name: "advert",
    pattern: "advert/sendMail",
    defaults: "{area:exists}/{controller=Advert}/{action=SendMail}/{id?}"
                );

app.MapControllerRoute(
    name: "advert",
    pattern: "advert/Profile",
    defaults: "{area:exists}/{controller=Advert}/{action=Profile}/{id?}"
                );
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//      name: "areas",
//      pattern: "{area:exists}/{controller=Advert}/{action=Index}/{id?}"
//    );
//});

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
