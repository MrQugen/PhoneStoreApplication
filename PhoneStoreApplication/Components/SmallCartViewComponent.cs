using Microsoft.AspNetCore.Mvc;
using PhoneStoreApplication.Extentions;
using PhoneStoreApplication.Models;
using PhoneStoreApplication.ViewModel;

namespace PhoneStoreApplication.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCartViewModel smallCartVM;

            if (cart == null || cart.Count == 0)
            {
                smallCartVM = null;
            }
            else
            {
                smallCartVM = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.UnitPrice)
                };
            }

            return View(smallCartVM);
        }
    }
}

