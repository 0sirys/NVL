using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NV.Services;
using NV.Models;

namespace NV.Controllers;

[ApiController]
[Route("[controller]")]

public class CRUDController : ControllerBase
{

    [HttpGet()]
    public async Task<IActionResult> datos()
    {
        Ser_CRUD algo = new Ser_CRUD();
        var result = algo.GetAll();
        await result;

        return Ok(result);
    }
    
    [HttpGet("[id]")]
    public async Task<IActionResult> datos(int id)
    {
        Ser_CRUD algo = new Ser_CRUD();
        var result = algo.GetAll();
        await result;

        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Entrega([FromForm]Product product){
        Ser_CRUD algo = new Ser_CRUD();
        var result = algo.PostProduct(product);
        await result;

        return Ok(result);

    }
}


