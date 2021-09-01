using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAuthentication.Models;

namespace LoginAuthentication.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductManager.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()    //for Create New Button on the Index page in Views Product folder
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Quantity,Price,SupplierID")] Product product)   //for Save Button on the Create.cshtml page
        {

            if (ModelState.IsValid)
            {
                ProductManager.AddProduct(product);
                return RedirectToAction("Index");  //redirect to the GetProducts() method above, the view in GetProducts() method will be returned
            }
            else
            {
                //something wrong with the data input, pop up error message
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)           //for Edit Button on the Index.cshtml page in Views Product folder
        {           
            var product = ProductManager.GetProductById(id);
           
            return View(product);   // return Edit.cshtml
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("ID,Name,Quantity,Price,SupplierID")] Product product)  //save product when save button is clicked
        {
            
            if (ModelState.IsValid)
            {
                ProductManager.UpdateProduct(product);

                return RedirectToAction("Index");  //redirect to the GetProducts() method above, the view in GetProducts() method will be returned
            }
            else
            {
                //something wrong with the data input, pop up error message
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult DeletePage(int id)           //for Edit Button on the Index.cshtml page in Views Product folder
        {
            var product = ProductManager.GetProductById(id);

            return View(product);   // return Edit.cshtml
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
          
            ProductManager.DeleteProduct(id);

            return RedirectToAction("Index");
        }
    }
}
