using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcOffice.Data;
using MvcOffice.Models;

var builder = WebApplication.CreateBuilder(args);
//��һ�������ݿ�����MvcOfficeContext  �ڶ����������ַ���
builder.Services.AddDbContext<MvcOfficeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcOfficeContext") ?? throw new InvalidOperationException("Connection string 'MvcOfficeContext' not found.")));
//����ע��  ���û����� ����ʹ��productController�ᱨ�� �˴�����ֱ�����Ϊ ��ʹ��productcontroller
//���������IProductRepository  FakeProductRepository��ֱ�ӳ䵱ʵ�ʽ���  transint��ȡʵ��
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
//www�ļ���Ϊ��̬�ļ�
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseMvc();
//app.UseMvcWithDefaultRoute();
app.Run();
