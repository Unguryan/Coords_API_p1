using Coords.Infrastructure;
using Coords.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);


var policyName = "defaultAngularCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName, builder =>
    {
        builder.WithOrigins("https://localhost:44439")
            .AllowAnyMethod()
            .AllowAnyHeader()
            //.AllowAnyOrigin()
            .AllowCredentials();
    });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRabbit(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policyName);

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();
