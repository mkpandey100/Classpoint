using Asp.Versioning;
using ClassPoint.API.Extensions;
using ClassPoint.Application.Extensions;
using ClassPoint.Domain.Constants;
using ClassPoint.Infrastructure.Persistance.Extensions;
using ClassPoint.Infrastructure.Shared.Extensions;
using ClassPoint.Infrastructure.Identity.Extensions;
using ClassPoint.Application.Dto.UserDto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string[] origins = [];
JwtIssuerOptions config = null;
#if DEBUG
        config = builder.Configuration.GetSection(nameof(JwtIssuerOptions)).Get<JwtIssuerOptions>();
        origins = builder.Configuration["CORS_ORIGINS"]?.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
#else
        origins = System.Environment.GetEnvironmentVariable("CORS_ORIGINS")?.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
        config = Newtonsoft.Json.JsonConvert.DeserializeObject<JwtIssuerOptions>(configString);
#endif

builder.Services.AddCors(options =>
{
    options.AddPolicy("PrototypeCorsPolicy",
        builder =>
        {
            builder
                .SetIsOriginAllowed(_ => true)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .Build();
        });
});
string privateKey = builder.Configuration[Authentication.AuthKey] ??
                    System.Environment.GetEnvironmentVariable(Authentication.AuthKey);

builder.Services
    .AddSwaggerConfiguration()
    .AddPersistenceInfrastructure(builder.Configuration)
    .AddIdentityAuthInfrastructure(privateKey, config)
    .AddInfrastructureSharedLayer()
    .AddApplicationLayer()
    .AddWebApiLayer();

builder.Services.AddControllers();

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("PrototypeCorsPolicy");

app.MapControllers();

app.Run();