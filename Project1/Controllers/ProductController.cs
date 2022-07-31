using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.DAL;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    
namespace Project1.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL db = new ProductDAL();
        CartDAL cd = new CartDAL();
        OrderDAL od = new OrderDAL();
        // GET: ProductController
        public ActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }
        public ActionResult Products()
        {
            var model = db.GetAllProducts();
            return View(model);
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int Id)
        {
            var model = db.GetProductById(Id);
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                int result = db.AddProduct(product);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int Id)
        {
            var model = db.GetProductById(Id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result = db.UpdateProduct(product);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int Id)
        {
            try
            {
                int result = db.DeleteProduct(Id);
                if (result == 1)


                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }
       
        public IActionResult AddToCart(int id)
        {
            string Uid = HttpContext.Session.GetString("Uid");
            Cart cart = new Cart();
            cart.Id = id;
            cart.Uid = Convert.ToInt32(Uid);
            int res = cd.AddToCart(cart);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult ViewCart()
        {
            string Uid = HttpContext.Session.GetString("Uid");
            var model = cd.ViewFromCart(Uid);
            return View(model);
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int Cid)
        {
            int res = cd.RemoveFromCart(Cid);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }
        public IActionResult ViewProductForOrder(int id)
        {
            string Uid = HttpContext.Session.GetString("Uid");
            Order or = new Order();
            or.Id = id;
            or.Uid = Convert.ToInt32(Uid);
            int res = od.PlaceOrder(or);
            if (res == 1)
            {
                return RedirectToAction("ViewOrder");
            }
            else
            {
                return View();
            }

           

        }
        [HttpGet]
        public IActionResult ViewOrder()
        {
            string Uid = HttpContext.Session.GetString("Uid");
            var model = od.ViewProductForOrder(Uid);
            return View(model);
        }
        [HttpGet]
        public IActionResult RemoveFromOrders(int Oid)
        {
            int res = od.RemoveFromOrders(Oid);
            if (res == 1)
            {
                return RedirectToAction("ViewOrder");
            }
            else
            {
                return View();
            }
        }

    }
}
