using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NV.Models;
#nullable disable
namespace NV.Services;

public class PR_CRUD
{

    public Task<List<Product>> GetAll(CountContext _Context)
    {
        return _Context.Products.ToListAsync();
    }
    public ValueTask<Product> GetProduct(CountContext _Context, int Id)
    {
        var algo = _Context.Products.FindAsync(Id);
        return algo;
    }
    public async Task<int> PostProduct(CountContext _Context, Product product)
    {
        await _Context.Products.AddAsync(product);
        var algo = _Context.SaveChangesAsync().Result;

        return algo;
    }





}