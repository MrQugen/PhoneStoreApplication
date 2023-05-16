namespace PhoneStoreApplication.Models
{
    public class CartItem
    {
        public int PhoneId { get; set; }

        public string PhoneName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total
        {
            get { return UnitPrice * Quantity; }
        }

        public string ImageUrl { get; set; }

        public CartItem()
        {

        }

        public CartItem(Phone phone)
        {
            PhoneId = phone.Id;
            PhoneName = phone.PhoneNaming;
            UnitPrice = phone.Price;
            Quantity = 1;
            ImageUrl = phone.ImageUrl;
        }
    }
}
