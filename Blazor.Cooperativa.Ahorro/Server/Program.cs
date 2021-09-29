using Cooperativa.Ahorro.Repository;
using Microsoft.AspNetCore.ResponseCompression;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//Inyeccion de los repositorios

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();
// Add Services to the container

//Inyectar base datos
string bdConnectionString = builder.Configuration.GetConnectionString("DefaulConnection");
builder.Services.AddSingleton<IDbConnection, DbConnection>((sp) => new SqlConnection(bdConnectionString));


//Inyeccion de repository
builder.Services.AddScoped<ITUsuarioRepository, TUsuarioRepository>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
