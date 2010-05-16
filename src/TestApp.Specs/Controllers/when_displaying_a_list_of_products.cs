using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Machine.Specifications;
using Rhino.Mocks;
using WebUI.Controllers;

namespace TestApp.Specs.Controllers
{
    [Subject("Product Controller")]
    public class when_displaying_a_list_of_products
    {
        Establish context =
            () =>
            {
                IProductsRepository r =
                    MockRepository.GenerateMock<IProductsRepository>();
                r.Expect(x => x.Products).Return(
                    new List<Product>
                                {
                                    new Product {Name = "P1"},
                                    new Product {Name = "P2"},
                                    new Product {Name = "P3"},
                                    new Product {Name = "P4"},
                                    new Product {Name = "P5"}
                                }.AsQueryable());

                controller = new ProductsController(r);
                controller.PageSize = 3;
            };

        Because of = () => result = controller.List(2);

        It has_a_non_null_result
            = () => result.ShouldNotBeNull();

        It has_the_correct_number_of_products
            = () =>
                  {
                      repo =
                          ((IList<Product>)result.ViewData.Model);
                      repo.Count.ShouldEqual(2);
                  };

        It has_the_correct_values_for_products
            = () =>
                  {
                      repo[0].Name.ShouldEqual("P4");
                      repo[1].Name.ShouldEqual("P5");
                  };

        static ProductsController controller;
        static ViewResult result;
        static IList<Product> repo;
    }
}
