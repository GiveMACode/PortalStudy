using System.Text.Json.Serialization;
using backend.Data;
using backend.Service.Endereco;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<ViaCepService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDataContext>(o => o.UseSqlite("Data Source=ApiDataBase.db;Cache=shared"));
builder.Services.AddControllers().AddJsonOptions(options =>{
     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
     options.JsonSerializerOptions.WriteIndented = true;
 });

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthentication();

app.MapControllers();


app.Run();

