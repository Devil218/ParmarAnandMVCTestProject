using AspnetCoreMvcFull.Repositorys;
using AspnetCoreMvcFull.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json",optional: true,reloadOnChange : true);





builder.Services.AddTransient<ICustomersServices, CustomersServicescs>();
builder.Services.AddTransient<ICustomersRepository, CustomersRepository>();

builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();

builder.Services.AddTransient<IOrdersServices, OrdersServices>(); 
builder.Services.AddTransient<IOrersRepository, OrdersRepository>(); 

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
    pattern: "{controller=Dashboards}/{action=Index}/{id?}");

app.Run();
