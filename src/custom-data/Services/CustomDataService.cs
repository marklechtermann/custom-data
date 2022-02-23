using System.Reflection;
using System.Text;

namespace github.com.marklechtermann.customdata;

public class CustomDataService
{
    private readonly string _data = "Hello World!";

    public CustomDataService()
    {
        var builder = new StringBuilder();
        var assemblies = new List<Assembly?> { Assembly.GetEntryAssembly(), typeof(CustomDataService).Assembly };

        assemblies.ForEach(a =>
        {
            if (a == null) { return; }
            builder.AppendLine("");
            builder.AppendLine(a.FullName);
            builder.AppendLine(a.GetName().Version?.ToString() ?? string.Empty);
            a.GetCustomAttributesData().ToList().ForEach(ca =>
            {
                builder.Append(ca.AttributeType.Name);
                builder.Append(':');
                builder.AppendLine(ca.ToString());
            });
        });
        _data = builder.ToString();
    }

    public string GetData()
    {
        return _data;
    }
}
