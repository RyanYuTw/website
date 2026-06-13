using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "ShoppingCart";

        private CartViewModel GetCart()
        {
            var cart = Session[CartSessionKey] as CartViewModel;
            if (cart == null)
            {
                cart = new CartViewModel { Items = new List<CartItem>() };
                Session[CartSessionKey] = cart;
            }
            return cart;
        }

        // GET: /Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        // POST: /Cart/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int productId, int qty)
        {
            if (qty < 1) qty = 1;

            using (var db = new AppDbContext())
            {
                var product = db.Products.FirstOrDefault(p => p.Id == productId && p.IsActive);
                if (product == null)
                    return Json(new { success = false, message = "商品不存在" });

                var cart = GetCart();
                var existing = cart.Items.FirstOrDefault(x => x.ProductId == productId);
                if (existing != null)
                {
                    existing.Quantity += qty;
                }
                else
                {
                    cart.Items.Add(new CartItem
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        ImagePath = product.ImagePath,
                        UnitPrice = product.SalePrice ?? product.Price,
                        Quantity = qty
                    });
                }
                Session[CartSessionKey] = cart;
                return Json(new { success = true, totalQty = cart.TotalQty, productName = product.Name });
            }
        }

        // POST: /Cart/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int productId, int qty)
        {
            var cart = GetCart();
            var item = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                if (qty <= 0)
                {
                    cart.Items.Remove(item);
                }
                else
                {
                    item.Quantity = qty;
                }
            }
            Session[CartSessionKey] = cart;
            return RedirectToAction("Index");
        }

        // POST: /Cart/Remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int productId)
        {
            var cart = GetCart();
            cart.Items.RemoveAll(x => x.ProductId == productId);
            Session[CartSessionKey] = cart;
            return RedirectToAction("Index");
        }

        // GET: /Cart/Checkout
        [Authorize]
        public ActionResult Checkout()
        {
            var cart = GetCart();
            if (cart.TotalQty == 0) return RedirectToAction("Index");
            var vm = new CheckoutViewModel { Cart = cart };
            return View(vm);
        }

        // POST: /Cart/Checkout
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Cart = GetCart();
                return View(model);
            }
            // TODO: 建立訂單、清空購物車
            Session.Remove(CartSessionKey);
            return RedirectToAction("Complete");
        }

        // GET: /Cart/Complete
        public ActionResult Complete()
        {
            return View();
        }
    }
}
