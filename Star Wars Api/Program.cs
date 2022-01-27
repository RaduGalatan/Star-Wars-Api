

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<Star_Wars_Api.Repository.MainRepository>();
builder.Services.AddScoped<Star_Wars_Api.Repository.FilmRepository>();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Search Entities", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Search Film Entities ", Version = "v2" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Search Entities");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Search Film Entities ");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;
    var response = new { error = exception.Message };
    await context.Response.WriteAsJsonAsync(response);
}));

app.MapControllers();

app.Run();
