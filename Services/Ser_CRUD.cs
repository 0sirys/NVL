using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NV.Models;
#nullable disable
namespace NV.Services;

public class Ser_CRUD
{
    
  
    public Ser_CRUD() { }
    public Task<List<Customer>> GetAll(CountContext _Context)
    {
        return _Context.Customers.ToListAsync();
    }
    public ValueTask<Customer> GetCustomers(CountContext _Context,int id)
    {
        return _Context.Customers.FindAsync(id);
    }
    public ValueTask<Customer> GetCustomer(CountContext _Context,int Id)
    {
        var algo = _Context.Customers.FindAsync(Id);
        return algo;
    }
    public async Task<int> PostCustomer(CountContext _Context,Customer product)
    {
           await _Context.Customers.AddAsync(product);
           var algo =_Context.SaveChangesAsync().Result;
          
        return algo;
    }





}