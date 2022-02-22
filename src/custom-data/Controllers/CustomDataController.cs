using Microsoft.AspNetCore.Mvc;

namespace github.com.marklechtermann.customdata;

[ApiController]
[Route("api/custom-data")]
public class CustomDataController : ControllerBase
{
    public CustomDataController(CustomDataService customDataService)
    {
        CustomDataService = customDataService;
    }

    public CustomDataService CustomDataService { get; }

    [HttpGet]
    public ActionResult<string> Get()
    {
        return CustomDataService.GetData();
    }
}
