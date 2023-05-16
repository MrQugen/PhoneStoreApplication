using Microsoft.AspNetCore.Mvc;
using PhoneStoreApplication.Data.Repository;
using PhoneStoreApplication.Models;
using PhoneStoreApplication.Extentions;
using PhoneStoreApplication.ViewModel;

namespace PhoneStoreApplication.Controllers
{
    public class CartController : Controller
    {
        public readonly IGenericRepository<Phone> _phoneRepository;

        public CartController(IGenericRepository<Phone> phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public async Task<IActionResult> Add(long id)
        {
            Phone? phone = (await _phoneRepository.GetAsync(q => q.Id == id)).FirstOrDefault();

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.PhoneId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(phone));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been added!";

            return Redirect(Request.Headers["Referer"].ToString());
        }


        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartPhones = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.UnitPrice)
            };

            return View(cartVM);
        }

        public async Task<IActionResult> Decrease(long id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.PhoneId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.PhoneId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(long id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.PhoneId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }
    }
}
