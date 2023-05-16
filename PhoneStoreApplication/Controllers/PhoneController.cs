using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneStoreApplication.Data.Repository;
using PhoneStoreApplication.MocksData;
using PhoneStoreApplication.Models;
using PhoneStoreApplication.ViewModel;

namespace PhoneStoreApplication.Controllers
{
    public class PhoneController : Controller
    {
        public readonly IPhoneMock _phoneMock;
        public readonly IBrandMock _brandMock;

        public readonly IGenericRepository<Phone> _phoneRepository;
        public readonly IGenericRepository<PhoneBrand> _brandRepository;

        public PhoneController(IPhoneMock phoneMock, IBrandMock brandMock,
            IGenericRepository<Phone> phoneRepository,
            IGenericRepository<PhoneBrand> brandRepository)
        {
            _phoneMock = phoneMock;
            _brandMock = brandMock;

            _phoneRepository = phoneRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(int? brandId){

            var viewModel = new FilteredPhonesViewModel();

            if(!brandId.HasValue)
            {
                viewModel.FilteredPhones = await _phoneRepository.GetAsync();
            }
            else
            {
                viewModel.FilteredPhones = await _phoneRepository.GetAsync(q => q.PhoneBrandId == brandId);
            }

            var brands = await _brandRepository.GetAsync();

            viewModel.PhonesBrands = brands.ToList().ConvertAll(b =>
            {
                return new SelectListItem()
                {
                    Text = b.BrandName.ToString(),
                    Value = b.Id.ToString(),
                };
            });

            return View(viewModel);
        }
    }
}

