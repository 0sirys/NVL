using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NV.Services;
using NV.Models;

namespace NV.Controllers;

[ApiController]
[Route("[controller]")]

public class CRUDController : ControllerBase
{
    internal readonly CountContext _Context = new CountContext();
    public CRUDController(CountContext context){
        this._Context=context;
    }
    

    [HttpGet()]
    public async Task<List<Customer>> datos()
    {
        Ser_CRUD algo = new Ser_CRUD();
        var result = algo.GetAll(_Context);
        await result;

        return result.Result;
    }
    
    [HttpGet("{id}")]
    public async Task<Customer> datos(int id)
    {
        Ser_CRUD algo = new Ser_CRUD();
        var result = algo.GetCustomer(_Context,id);
        await result;

        return result.Result;
    }
    [HttpPost]
    public async Task Entrega([FromForm] Customer product){
        Ser_CRUD algo = new Ser_CRUD();
        while(true){

            Console.WriteLine("hola");
        }
    }
}


