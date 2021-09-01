using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCFramework.Models;

namespace WebMVCFramework.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product List
        public ActionResult Index()
        {
            var products = ProductManager.GetProducts();
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }
        
       // POST: Product/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
       {
           try
           {
               if (ModelState.IsValid)
               {
                   var product = new Product();
                   product.Name = collection["Name"];
                   product.Quantity = Convert.ToInt32(collection["Quantity"]);
                   product.Price = Convert.ToDecimal(collection["Price"]);
                   product.SupplierID = Convert.ToInt32(collection["SupplierID"]);

                   ProductManager.AddProduct(product);
                   return RedirectToAction("Index");  //redirect to the GetProducts() method above, the view in GetProducts() method will be returned
               }              
            }
           catch (Exception ex)
           {
               //Logger.Instance.Critical($"Error occured in UserManager.Authenticate: {ex.Message}");
           }
           return View();
       } 

       // GET: Product/Edit/5
       [HttpGet]
       public ActionResult Edit(int id)
       {
           var product = ProductManager.GetProductById(id);

           return View(product);
       }

       
       // POST: Product/Update/5
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
       {
           
           try
           {

               if (ModelState.IsValid)
               {
                   var product = new Product();
                   product.ID = Convert.ToInt32(collection["ID"]);
                   product.Name = collection["Name"];
                   product.Quantity = Convert.ToInt32(collection["Quantity"]);
                   product.Price = Convert.ToDecimal(collection["Price"]);
                   product.SupplierID = Convert.ToInt32(collection["SupplierID"]);
                   ProductManager.UpdateProduct(product);

                   return RedirectToAction("Index");  //redirect to the GetProducts() method above, the view in GetProducts() method will be returned
               }
           }
           catch (Exception ex)
           {
               //Logger.Instance.Critical($"Error occured in UserManager.Authenticate: {ex.Message}");
           }
           return View();
       }   

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = ProductManager.GetProductById(id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ProductManager.DeleteProduct(id);

            return RedirectToAction("Index");
        }

        /*
        // POST: Product/Update/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            foreach (string key in collection.AllKeys)
            {
                Response.Write("Key =" + key + " ");
                Response.Write(collection[key]);
                Response.Write("<br");
            }
            return View();
        } */

        /*
        // POST: Product/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            foreach (string key in collection.AllKeys)
            {
                Response.Write("Key =" + key + " ");
                Response.Write("Value =" + collection[key]);
                Response.Write("<br");
            }
            return View();
        } */
    }
}
