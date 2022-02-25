using System.Reflection;
using github.com.marklechtermann.customdata;

if (args.Length > 0 && string.Equals(args[0], "--version", StringComparison.OrdinalIgnoreCase))
{
    var versionAttribute = typeof(Program).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), true).OfType<AssemblyInformationalVersionAttribute>().FirstOrDefault();

    if (versionAttribute != null)
    {
        Console.WriteLine($"Welcome to Version {versionAttribute.InformationalVersion}");
    }
    else
    {
        Console.WriteLine($"Welcome to Version 0.0.0");
    }

    Environment.Exit(0);
}



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
