using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NV.Models;
#nullable disable
namespace NV.Services;

public class Ser_CRUD
{
    internal CountContext _Context = new CountContext();
    public Ser_CRUD() { }
    public Task<List<Client>> GetAll()
    {
        return _Context.Clients.ToListAsync();
    }
    public Task<List<Product>> GetProducts()
    {
       
        return _Context.Products.ToListAsync();
    }
    public   ValueTask<Product> GetProduct(int Id){
       var algo  =   _Context.Products.FindAsync(Id);

        return algo ;
    }


}