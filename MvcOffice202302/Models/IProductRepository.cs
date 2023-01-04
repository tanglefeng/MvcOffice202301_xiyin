using System.Linq;
namespace MvcOffice.Models
  
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
       
    }
}
