using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ContextDB>(options => options.UseMySql(builder.Configuration["ConnectionStrings:DefaultConnection"], new MySqlServerVersion(new Version(8, 0, 22))));
builder.Services.AddDbContext<ContextDB>(options => options.UseInMemoryDatabase("test"));

// добавление кэширования
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IFio, FioRepository>();
builder.Services.AddScoped<ICompany, CompanyRepository>();
builder.Services.AddScoped<IUser, UserRepository>();

var app = builder.Build();
app.UseCors(option => 
option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

//public class User
//{
//    public int Id { get; set; }

//    public string Login { get; set; } = null!;

//    public string Password { get; set; } = null!;

//    public string Name { get; set; } = null!;

//    public string Surname { get; set; } = null!;

//    public string? Patronomic { get; set; }

//    public DateTime Birthday { get; set; }

//    public string Mail { get; set; } = null!;

//    public string PhoneNumber { get; set; } = null!;
//}
//public class ApplicationContext : DbContext
//{
//    public DbSet<User> Users { get; set; } = null!;
//    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) =>
//        Database.EnsureCreated();
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        // инициализация БД начальными данными
//        modelBuilder.Entity<User>().HasData(
//                new User { Id = 1, Login = "admin", Password = "admin", Name = "Админ", Surname = "Админов", Patronomic = "Админович", Birthday = new DateTime(), Mail = "admin@mail.ru", PhoneNumber = "89530994567", },
//                new User { Id = 1, Login = "admin", Password = "admin", Name = "Админ", Surname = "Админов", Patronomic = "Админович", Birthday = new DateTime(), Mail = "admin@mail.ru", PhoneNumber = "89530994567", },
//                new User { Id = 1, Login = "admin", Password = "admin", Name = "Админ", Surname = "Админов", Patronomic = "Админович", Birthday = new DateTime(), Mail = "admin@mail.ru", PhoneNumber = "89530994567", },
//                new User { Id = 1, Login = "admin", Password = "admin", Name = "Админ", Surname = "Админов", Patronomic = "Админович", Birthday = new DateTime(), Mail = "admin@mail.ru", PhoneNumber = "89530994567", }
               
//        );
//    }
//}
//public class UserService
//{
//    ApplicationContext db;
//    IMemoryCache cache;
//    public UserService(ApplicationContext context, IMemoryCache memoryCache)
//    {
//        db = context;
//        cache = memoryCache;
//    }
//    public async Task<User?> GetUser(int id)
//    {
//        // пытаемся получить данные из кэша
//        cache.TryGetValue(id, out User? user);
//        // если данные не найдены в кэше
//        if (user == null)
//        {
//            // обращаемся к базе данных
//            user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
//            // если пользователь найден, то добавляем в кэш - время кэширования 5 минут
//            if (user != null)
//            {
//                Console.WriteLine($"{user.Name} извлечен из базы данных");
//                cache.Set(user.Id, user, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
//            }
//        }
//        else
//        {
//            Console.WriteLine($"{user.Name} извлечен из кэша");
//        }
//        return user;
//    }
//}