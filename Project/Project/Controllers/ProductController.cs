using DataAccessLayeProduct;
using DataAccessLayeProductCategories;

using ProductModel;
using System.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Project.Controllers
{
    public class ProductController : Controller
    {
        DataLaye dataLaye = new DataLaye();//product DataLayaer
        DataLayeCategories dataLayeCategories = new DataLayeCategories();
        Product product = new Product();
        // GET: Product
        public class ParamaeterInfo
        {
            public string varName { get; set; }           
            public string productCategory { get; set; }
         }           
        public ActionResult GetList(ParamaeterInfo paramaeterInfo)
        {
            dynamic model = new ExpandoObject();
            model.ProductCategories = dataLayeCategories.GetList();
            model.ProductCategories = new SelectList(model.ProductCategories, "Name", "Name");
            //ViewBag.productCategoriesBag = new SelectList(productCategories, "Name","Name");


            if (paramaeterInfo.varName != null || paramaeterInfo.productCategory != null)
            {
                List<Product> list1 = dataLaye.Search(paramaeterInfo.varName, paramaeterInfo.productCategory);
                model.Product = list1;
                return View(model);
            }
            else
            {
                List<Product> list1 = dataLaye.GetList();
                model.Product = list1;
                return View(model);
            }
        }
        //INSERT: Customer
        [HttpGet]
        public ActionResult ProductsInsert()
        {
            DataLayeCategories dataLayeCategories = new DataLayeCategories();
            product.ProductCategoriesList = dataLayeCategories.GetList();
           
            return View(product);
        }
        [HttpPost]
        public ActionResult ProductsInsert(Product product)
        {
            DataLaye dataLaye = new DataLaye();
            bool lsitobj = dataLaye.Save(product);
            return RedirectToAction("GetList");
        }

    }
}