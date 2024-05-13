using DataAccessLayeProductCategories;
using ProductCategoriesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ProductCategoriesController : Controller
    {
        DataLayeCategories dataLaye = new DataLayeCategories();

        // GET: ProductCategories
        public ActionResult GetList()
        {
            List<ProductCategories> list = dataLaye.GetList();
          
            return View(list);
         
        }
    }
}