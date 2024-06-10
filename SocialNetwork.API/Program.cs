using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SocialNetwork.API.Interactions.Application.Internal.CommandServices;
using SocialNetwork.API.Interactions.Application.Internal.QueryServices;
using SocialNetwork.API.Interactions.Domain.Repositories;
using SocialNetwork.API.Interactions.Domain.Services;
using SocialNetwork.API.Interactions.Infrastructure.Persistence.EFC.Repositories;
using SocialNetwork.API.Shared.Domain.Repositories;
using SocialNetwork.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Aniadir services

builder.Services.AddControllers(
    options =>
    {
        options.Conventions.Add(new KebabCaseRouteNamingConvention());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion a base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurando Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "SocialNetwork.API",
                Version = "v1",
                Description = "Social Network Web API",
                TermsOfService = new Uri("https://peace-app/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Social Network App",
                    Email = "snt@x.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });
// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);


// Shared Bounded Context Configuracion de inyeccion
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Interactions Bounded Context Configuracion de Inyeccion
builder.Services.AddScoped<IFollowingInteractionRepository, FollowingInteractionRepository>();
builder.Services.AddScoped<IFollowingInteractionCommandService, FollowingInteractionCommandService>();
builder.Services.AddScoped<IFollowingInteractionQueryService, FollowingInteractionQueryService>();

// Interactions Bounded Context Configuracion de Inyeccion
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusCommandService, StatusCommandService>();
builder.Services.AddScoped<IStatusQueryService, StatusQueryService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Verify Database objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


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

