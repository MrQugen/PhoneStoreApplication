using PhoneStoreApplication.Models;

namespace PhoneStoreApplication.MocksData
{
    public interface IBrandMock
    {
        IEnumerable<PhoneBrand> PhoneBrands { get; }
    }
}
