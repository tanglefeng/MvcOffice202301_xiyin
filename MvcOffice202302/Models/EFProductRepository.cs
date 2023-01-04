using MvcOffice.Data;

namespace MvcOffice.Models
{
    public class EFProductRepository : IProductRepository
    {
        public MvcOfficeContext context;
        public EFProductRepository(MvcOfficeContext ctx)
        { 
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
    }
}
