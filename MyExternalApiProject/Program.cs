using MyExternalIntegrationApi.Repositories;
using MyExternalIntegrationApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositorios con HttpClient
builder.Services.AddHttpClient<IUserRepository, UserRepository>();
builder.Services.AddHttpClient<IPostRepository, PostRepository>();

// Servicios
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();

var app = builder.Build();

// Swagger solo en Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
