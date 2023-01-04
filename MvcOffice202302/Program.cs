using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcOffice.Data;
using MvcOffice.Models;

var builder = WebApplication.CreateBuilder(args);
//第一个是数据库名字MvcOfficeContext  第二个是链接字符串
builder.Services.AddDbContext<MvcOfficeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcOfficeContext") ?? throw new InvalidOperationException("Connection string 'MvcOfficeContext' not found.")));
//依赖注入  如果没有这个 后面使用productController会报错 此处可以直接理解为 当使用productcontroller
//调用里面的IProductRepository  FakeProductRepository会直接充当实际进入  transint获取实例
//builder.Services.AddTransient<IProductRepository, FakeProductRepository>();
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddTransient<ItimeRepository, timeRepository>();
builder.Services.AddTransient<IDepartmentMembers, EFDepartmentMembers>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//www文件即为静态文件
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseMvc();
//app.UseMvcWithDefaultRoute();
app.Run();
