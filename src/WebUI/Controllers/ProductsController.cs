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
        int _pageSize;

        public ProductsController(IProductsRepository repository)
        {
            _productsRepository = repository;
            _pageSize = 4;
        }

        public int PageSize
        {
            get {
                return _pageSize;
            }
            set {
                _pageSize = value;
            }
        }

        public ViewResult List(int page)
        {
            return View(_productsRepository.Products
                            .Skip((page - 1)*PageSize)
                            .Take(PageSize)
                            .ToList());
        }
    }
}
