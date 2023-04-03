using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using qandr_api.Models;
using qandr_api.Repo;
using qandr_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//For EF-core
builder.Services.AddDbContext<QandR_DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QandR_AppCon"));
});
// builder.Services.AddDbContext<EventDBContext>(options => options.UseInMemoryDatabase(databaseName: "BlogDB"));

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => 
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddScoped<IStudent, StudentServices>();
// builder.Services.AddScoped<ILecturer, LecturerServices>();
// builder.Services.AddScoped<IEvent, EventServices>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
