using Microsoft.EntityFrameworkCore;
using ApplicationServices;
using Persistence;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDatabase(connectionString);
builder.Services.AddRepositories();
builder.Services.AddServices();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();
CreateDbIfNotExists(app.Services);
app.Run();

void CreateDbIfNotExists(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var services = scope.ServiceProvider;
    try
    {

        var context = services.GetRequiredService<CantinaBvContext>();
        DbInitializer.Initialize(context);
    }
    catch(Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured creating the DB.");
    }
}
