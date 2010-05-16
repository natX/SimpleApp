using Domain.Abstract;
using Domain.Concrete;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace WebUI
{
    public class DomainRegistry
        : Registry
    {
        public DomainRegistry()
        {
            For<IProductsRepository>().Use<FakeProductsRepository>(); 
        }
    }
}