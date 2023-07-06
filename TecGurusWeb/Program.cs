using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TecGurusCommon.Domain;
using TecGurusCommon.Interfaces;
using TecGurusCommon.Services;
using TecGurusFactory.Factories;
using TecGurusFactory.Interfaces;
using TecGurusInfraestructure.EF;
using TecGurusWeb.Data;
using TecGurusWeb.EFDBFirstExample;
using TecGurusWeb.ExampleDI;
using TecGurusWeb.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Cada vez que se use EF con un DBContext debo especificar en el Program el uso de la Cadena de Conexión con el contexto
var connectionStringFirst = builder.Configuration.GetConnectionString("DBFirstConnection") ?? throw new InvalidOperationException("Connection string 'DBFirstConnection' not found.");
builder.Services.AddDbContext<DBContextDBFirst>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDbContext<DBContextTecGurus>(options =>
    options.UseSqlServer(connectionString));


//Registro de Inyecciones pemitidas en el proyecto -> (permitit la instacia del objeto)
//Add Scope realiza el registro de la inyeccion y crea una instancia unica en el proyecto

//Repository
builder.Services.AddScoped(typeof(IEFRepository<>), typeof(EFRepository<>));


//Services
builder.Services.AddScoped<IDiasService, DiasService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

//Factory
builder.Services.AddScoped<IProductModelFactory, ProductModelFactory>();
builder.Services.AddScoped<ICategoryModelFactory, CategoryModelFactory>();

//Utils(AutoMapper)

var mappingConfig = new MapperConfiguration(
    mc =>
    {
        mc.AddProfile(new DomainProfile());
    });
IMapper mapper= mappingConfig.CreateMapper();

builder.Services.AddSingleton(mapper);



builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapRazorPages();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.MapControllers();



app.Run();
