using Microsoft.AspNetCore.Mvc;
using NV.Services;
using NV.Models;

namespace NV.Controllers;
[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{
    private readonly CountContext _context = new CountContext();
    public ProductController(CountContext context)
    {
        this._context = context;
    }
    [HttpGet()]
    public async Task<List<Product>> GetProducts()
    {
        PR_CRUD service = new PR_CRUD();
        var result = service.GetAll(_context);
        await result;
        return result.Result;

    }
    
    [HttpPost()]

    public async Task<int> PostProduct(Product product){
        PR_CRUD service = new PR_CRUD();
        var result = service.PostProduct(_context,product);
        await result;
        return result.Result;
    }



}