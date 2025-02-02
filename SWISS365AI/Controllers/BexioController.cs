using Microsoft.AspNetCore.Mvc;
using RestSharp;

[Route("api/bexio")]
[ApiController]
public class BexioController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public BexioController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("getContacts")]
    public async Task<IActionResult> GetContacts()
    {
        var client = new RestClient("https://api.bexio.com/2.0/contact");
        var request = new RestRequest(Method.GET);
        request.AddHeader("Authorization", "Bearer " + _configuration["Bexio:ApiKey"]);

        var response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }
}
