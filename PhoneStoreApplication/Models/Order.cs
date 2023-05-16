using System.ComponentModel.DataAnnotations;

namespace PhoneStoreApplication.Models
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderedPhones = new List<OrderItems>();
        }

        [Display(Name ="Повне ім'я")]
        [MinLength(5)]
        [Required(ErrorMessage ="Довжина не мешне 5 симовлів")]
        public string CustomerFullName { get; set; }

        [Display(Name = "Ваша адреса")]
        [MinLength(5)]
        [Required(ErrorMessage = "Довжина не мешне 5 симовлів")]
        public string Address { get; set; }

        [Display(Name = "Побажання")]
        [MinLength(5)]
        [Required(ErrorMessage = "Довжина не мешне 5 симовлів")]
        public string Directions { get; set; }

        [Display(Name = "Номер телeфону")]
        [MinLength(9)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Довжина не менше 9 символів")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public List<OrderItems> OrderedPhones { get; set; }
    }
}
