using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Domaine;
using HashidsNet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



builder.Services.AddScoped<IQuizRepository, DbQuizRepo>();
builder.Services.AddScoped<ILevelRepository, DbLevelRepo>();
builder.Services.AddScoped<ISujetRepository, DbSujetlRepo>();

builder.Services.AddScoped<IQuestionRepository, DbQuestionRepository>();

builder.Services.AddScoped<IAnswerRepository, DbTheAnswerRepo>();
builder.Services.AddScoped<IUserRepository, DbUserRepo>();

// add middlware hashids
builder.Services.AddSingleton<IHashids>(_ =>new Hashids("gael", 11));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
