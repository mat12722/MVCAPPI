using MVCAPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace MVCAPPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ViewProducts()
        {
            ViewBag.Message = "Products List";
            var data = ProductProcessor.LoadProducts();
            List<ProductModel> products = new List<ProductModel>();
            foreach(var row in data)
            {
                products.Add(new ProductModel
                {
                    Code = row.Code,
                    Name = row.Name,
                    Description = row.Description,
                    Price = row.Price,
                    Category_Id = row.Category_Id
                });
            }
            return View(products);
        }
        public ActionResult Insert()
        {
            ViewBag.Message = "Insert Product";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(ProductModel model)
        {
            if(ModelState.IsValid)
            {
                int rec = ProductProcessor.CreateProduct(model.Code,model.Name,model.Description,model.Price,model.Category_Id);
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult Delete()
        {
            ViewBag.Message = "Insert Product";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductModel model)
        { 
            int rec = ProductProcessor.DeleteProduct(model.Code);
            return RedirectToAction("Index");
        }
        public ActionResult Update()
        {
            ViewBag.Message = "Insert Product";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductModel model)
        {
            int rec = ProductProcessor.UpdateProduct(model.Code, model.Name, model.Description, model.Price, model.Category_Id);
            return RedirectToAction("Index");
        }
    }
}