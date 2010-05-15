using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;

namespace WebUI.Controllers
{
    public class ProductsController 
        : Controller
    {
        private IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository repository)
        {
            _productsRepository = repository;
        }

        public ViewResult List()
        {
            return View(_productsRepository.Products.ToList());
        }
    }
}
