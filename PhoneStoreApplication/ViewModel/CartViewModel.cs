using PhoneStoreApplication.Models;

namespace PhoneStoreApplication.ViewModel
{
    public class CartViewModel
    {
        public List<CartItem> CartPhones { get; set; }

        public decimal GrandTotal { get; set; }
    }
}

