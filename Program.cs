using SpaceX.Api.Services;

var builder = WebApplication.CreateBuilder(args);
const string AllowSpacexApi = "AllowSpacexApiCorsPolicy";

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IApiRequestService, ApiRequestService>();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(AllowSpacexApi,
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "My SpaceX API");
    opt.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(AllowSpacexApi);

app.MapControllers();

app.Run();
