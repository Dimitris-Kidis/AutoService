
using AutoService.ExceptionFilter;
using AutoService.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRepository()
    .AddDbContext(builder)
    .AddMapper()
    .AddCorsPolicy()
    .AddSwaggerServices()
    .AddMediatRConfigs()
    .AddControllers(option => option.Filters.Add(typeof(ApiExceptionFilter)));
    //.AddValidators();
builder.Services.AddJwt().AddIdentityConfiguration();






var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseDbTransactionMiddleware();

app.MapControllers();

app.Run();
