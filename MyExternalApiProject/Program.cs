using MyExternalIntegrationApi.Repositories;
using MyExternalIntegrationApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Registro de Repositorios con HttpClient (Typed Clients)
builder.Services.AddHttpClient<IUserRepository, UserRepository>();
builder.Services.AddHttpClient<IPostRepository, PostRepository>();
builder.Services.AddHttpClient<IUserService, UserService>();
builder.Services.AddHttpClient<IPostService, PostService>();

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
