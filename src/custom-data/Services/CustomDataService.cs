namespace github.com.marklechtermann.customdata;

public class CustomDataService
{
    private readonly string _data = "Hello World!";

    public CustomDataService()
    {
    }

    public string GetData()
    {
        return _data;
    }
}
