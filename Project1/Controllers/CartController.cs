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
    public class CartController : Controller
    {
        ProductDAL db = new ProductDAL();
        CartDAL cd = new CartDAL();
        public IActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
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







    }
}
