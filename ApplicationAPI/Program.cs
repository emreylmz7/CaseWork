using ApplicationAPI.Data.Abstract;
using ApplicationAPI.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => {
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection"); 
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IJobPositionRepository,EfJobPositionRepository>();
builder.Services.AddScoped<IJobApplicationRepository,EfJobApplicationRepository>();
builder.Services.AddScoped<IUserRepository,EfUserRepository>();



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

SeedData.FillTestData(app);

app.MapControllers();

app.Run();
