using CMED_BusinessLayer.Service;
using CMED_DataAcessLayer.Data;
using CMED_DataAcessLayer.Interface;
using CMED_DataAcessLayer.Repository;
using CMED_WEB.DateConverter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRegistration, RepositoryRegistration>();
builder.Services.AddTransient<IPrescription, RepositoryPrescription>();
builder.Services.AddTransient<PrescriptionService>();
builder.Services.AddTransient<RegistrationService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.Converters.Add(new DateConverter());
//});
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
