using PhoneStoreApplication.Models;

namespace PhoneStoreApplication.MocksData
{
    public interface IPhoneMock
    {
        IEnumerable<Phone> Phones { get; }
    }
}
