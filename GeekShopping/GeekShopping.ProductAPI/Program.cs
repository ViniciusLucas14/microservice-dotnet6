using AutoMapper;
using GeekShopping.ProductAPI.Domain.Config;
using GeekShopping.ProductAPI.Domain.IRepository;
using GeekShopping.ProductAPI.Implementation.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//MAPPER
IMapper mapper = Mapping.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Inject repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();    

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Api Shopping" });
});

var connection = builder.Configuration["connection"];
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
//#if DEBUG
                    .AllowAnyOrigin()
//#else

//                    .WithOrigins("https://*.shopmoura.com.br")
//#endif
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .SetPreflightMaxAge(TimeSpan.FromSeconds(600))
        .Build();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
