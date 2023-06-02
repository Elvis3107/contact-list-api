using contact_list_api;
using contact_list_api.Configurations;
using contact_list_api.Models;
using contact_list_api.Repository;
using contact_list_api.Services;
using contact_list_api.Services.Interface;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ContactContext>(opts => opts.UseMySQL(builder.Configuration["ConnectionString:ContactDB"]));

builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddScoped<IContactReposity<Contact>, ContactRepository>();

builder.Services.AddCors();



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ContactContext>();
    context.Database.Migrate();
}


app.AddGlobalErrorHandler();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
