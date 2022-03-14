using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using ShopsRCUS.Discount.API.Entities.Models;
using ShopsRCUS.Discount.API.Entities.Settings;
using ShopsRCUS.Discount.API.Services.Implementations;
using ShopsRCUS.Discount.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setupAction =>
{
    setupAction.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopsRUSDiscountDbContext>(options =>
{
    var con = builder.Configuration.GetConnectionString("DiscountConnectionString");
    options.UseSqlite(con);
});

builder.Services.AddScoped<IRepositoryService,RepositoryService>();

builder.Services.AddScoped<IHashingService, BcryptHashService>();

builder.Services.AddScoped<IDiscountService, DiscountService>();

// Add AppSetting Configuration
var discountSetting = new DiscountSetting();
builder.Configuration.GetSection("DiscountSetting").Bind(discountSetting);
builder.Services.AddSingleton<DiscountSetting>(discountSetting);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler(appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected error happened. Try again later");
        });
    });
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
