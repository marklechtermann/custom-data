using github.com.marklechtermann.customdata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CustomDataService>();
builder.Services.AddMvc().AddApplicationPart(typeof(CustomDataController).GetType().Assembly);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();


