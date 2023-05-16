using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStoreApplication.Models
{
    public class OrderItems : BaseEntity
    {
        public int PhoneId { get; set; }

        public string PhoneName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public decimal Total
        {
            get { return UnitPrice * Quantity; }
        }

        public OrderItems()
        {

        }

        public OrderItems(CartItem cart)
        {
            PhoneId = cart.PhoneId;
            PhoneName = cart.PhoneName;
            UnitPrice = cart.UnitPrice;
            Quantity = cart.Quantity;
        }
    }
}
