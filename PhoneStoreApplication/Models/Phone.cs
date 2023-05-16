using PhoneStoreApplication.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;
using OperatingSystem = PhoneStoreApplication.Enumerations.OperatingSystem;

namespace PhoneStoreApplication.Models
{
    public class Phone : BaseEntity
    {
        public string PhoneNaming { get; set; }

        public OperatingSystem OperatingSystem { get; set; }

        public decimal Price { get; set; }

        public ScreenType ScreenType { get; set; }

        public short RAM { get; set; }

        public short MainCamera { get; set; }

        public string ImageUrl { get; set; }

        public PhoneBrand PhoneBrand { get; set; }

        [ForeignKey("PhoneBrand")]
        public int PhoneBrandId { get; set; }

        public string Color { get; set; }

        public string Storage { get; set; }
    }
}
