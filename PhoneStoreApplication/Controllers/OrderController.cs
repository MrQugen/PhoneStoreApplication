using Microsoft.AspNetCore.Mvc;
using PhoneStoreApplication.Data.Repository;
using PhoneStoreApplication.Extentions;
using PhoneStoreApplication.Models;

namespace PhoneStoreApplication.Views
{
    public class OrderController : Controller
    {

        public readonly IGenericRepository<Order> _orderRepository;

        public OrderController(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
              return View(await _orderRepository.GetAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerFullName,Address,Directions,PhoneNumber,Email,Id")] Order order)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            if(cart == null || !cart.Any())
            {
                ModelState.AddModelError("", "Необхыдно добавити телефони до кошика перед оформленням замовлення!");
            }
           else
   
           // populate order items
           cart.ForEach(item => order.OrderedPhones.Add(
                new OrderItems(item)));

            if (ModelState.IsValid)
            {
                await _orderRepository.AddAsync(order);
                HttpContext.Session.Remove("Cart");

                return RedirectToAction(nameof(Index));
            }
            
            return View(order);
        }
    }
}
