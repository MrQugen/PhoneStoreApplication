using PhoneStoreApplication.Models;

namespace PhoneStoreApplication.MocksData
{
    public class BrandMock : IBrandMock
    {
        public IEnumerable<PhoneBrand> PhoneBrands => new List<PhoneBrand>
        {
            new PhoneBrand { BrandName = "Apple" },
            new PhoneBrand { BrandName = "Xiaomi" }
        };
    }
}

