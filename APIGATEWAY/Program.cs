using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add services for ocelot
//optional false means that the file must be present ocelot.json,
//if true if file is missing app thrown an error
//reloadOnChange means that if we change the file ocelot will automatically reload the configuration without restarting the app
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true); 


builder.Services.AddOcelot(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();
//add ocelot middleware
await app.UseOcelot();
app.Run();
