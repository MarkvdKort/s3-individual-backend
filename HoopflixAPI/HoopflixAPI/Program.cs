using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Usercontext>(o => o.UseSqlServer("Data Source=LAPTOP-SUOCM14P\\SQLEXPRESS;Initial Catalog=HoopFlix;Integrated Security=True"));
builder.Services.AddDbContext<LikeContext>(o => o.UseSqlServer("Data Source=LAPTOP-SUOCM14P\\SQLEXPRESS;Initial Catalog=HoopFlix;Integrated Security=True"));
builder.Services.AddDbContext<CurrentlyWatchingContext>(o => o.UseSqlServer("Data Source=LAPTOP-SUOCM14P\\SQLEXPRESS;Initial Catalog=HoopFlix;Integrated Security=True"));
builder.Services.AddDbContext<ViewHistoryContext>(o => o.UseSqlServer("Data Source=LAPTOP-SUOCM14P\\SQLEXPRESS;Initial Catalog=HoopFlix;Integrated Security=True"));
builder.Services.AddDbContext<VideoContext>(o => o.UseSqlServer("Data Source=LAPTOP-SUOCM14P\\SQLEXPRESS;Initial Catalog=HoopFlix;Integrated Security=True"));
builder.Services.AddDbContext<MyListContext>(o => o.UseSqlServer("Data Source=LAPTOP-SUOCM14P\\SQLEXPRESS;Initial Catalog=HoopFlix;Integrated Security=True"));
builder.Services.AddDbContext<ChatContext>(o => o.UseSqlServer("Data Source=LAPTOP-SUOCM14P\\SQLEXPRESS;Initial Catalog=HoopFlix;Integrated Security=True"));
builder.Services.AddDbContext<MessageContext>(o => o.UseSqlServer("Data Source=LAPTOP-SUOCM14P\\SQLEXPRESS;Initial Catalog=HoopFlix;Integrated Security=True"));
builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IMylistRepository, MyListRepository>();
builder.Services.AddScoped<IViewHistoryRepository, ViewHistoryRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICurrentlyWatchingRepository, CurrentlyWatchingRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();


var app = builder.Build();
int port = Convert.ToInt32(Environment.GetEnvironmentVariable("ASPNETCORE_HTTPS_PORT") ?? "4000");
if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(serveroptions =>
    {
        serveroptions.ListenAnyIP(4000, listenoptions =>
        {
            listenoptions.UseHttps("certhttps.pfx", "PasswordAPI");
        });
        serveroptions.ListenAnyIP(80);
    });
    builder.Services.AddHttpsRedirection(options =>
    {
        options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
        options.HttpsPort = port;
    });
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000", "http://localhost:5000", "http://localhost:3001"));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
