using Domain.Abstract;
using Domain.Concrete;
using StructureMap.Configuration.DSL;

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