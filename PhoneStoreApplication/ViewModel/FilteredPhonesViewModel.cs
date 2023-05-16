using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneStoreApplication.Models;

namespace PhoneStoreApplication.ViewModel
{
    public class FilteredPhonesViewModel
    {
        public IEnumerable<Phone> FilteredPhones { get; set; }

        public List<SelectListItem> PhonesBrands { get; set; }
    }
}
