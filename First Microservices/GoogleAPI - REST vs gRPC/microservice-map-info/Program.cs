using GoogleMapInfo;
using microservice_map_info.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<GoogleDistanceApi>();     //transient: recreated at every request (even in same web req.)
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddGrpc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*****Calling and set up microservice from monolith*****/

//To inject IDistanceInfoSvc instances where used in constructors (es. QuoteSvc)
//Scoped: it creates one instance for each HTTP request, but it uses the same instance in the other calls within the same web request
builder.Services.AddScoped(typeof(IDistanceInfoSvc), typeof(DistanceInfoSvc));
//Retrieving microservice URL
var distanceMicroserviceUrl = builder.Configuration.GetSection("DistanceMicroservice:Location").Value;
//ONE instance of HttpClient for all calls to microservice (not instantatied each time)
builder.Services.AddHttpClient("DistanceMicroservice", client =>
{
    client.BaseAddress = new Uri(distanceMicroserviceUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGrpcService<DistanceInfoService>();
app.MapControllers();

app.Run();
