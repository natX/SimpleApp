using System.Linq;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IProductsRepository
    {
        IQueryable<Product> Products { get; }
    }
}