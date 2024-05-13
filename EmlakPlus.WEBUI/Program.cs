using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.Concrete;
using EmlakPlus.DAL.Abstract;
using EmlakPlus.DAL.Concrete.EfCore;
using EmlakPlus.WEBUI.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MapProfile));

//Dependency Injection

builder.Services.AddScoped<IProductService, ProductManager>();   
builder.Services.AddScoped<IProductDal, EfCoreProductDal>();

builder.Services.AddScoped<IProductTypeService, ProductTypeManager>();
builder.Services.AddScoped<IProductTypeDal, EfCoreProductTypeDal>();

builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<ISliderDal, EfCoreSliderDal>();

builder.Services.AddScoped<IWhoWeAreService, WhoWeAreManager>();
builder.Services.AddScoped<IWhoWeAreDal, EfCoreWhoWeAreDal>();

builder.Services.AddScoped<IAgencyService, AgencyManager>();
builder.Services.AddScoped<IAgencyDal, EfCoreAgencyDal>();

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
