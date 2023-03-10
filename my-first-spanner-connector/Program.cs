using Google.Cloud.EntityFrameworkCore.Spanner.Extensions;
using my_first_spanner_connector.entitymodel;

var builder = WebApplication.CreateBuilder(args);
string connection = "";

//builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
//    .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
//    .AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SampleContext>(options =>
options.UseSpanner(connection));

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
