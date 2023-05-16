using PhoneStoreApplication.Models;

namespace PhoneStoreApplication.MocksData
{
    public class PhoneMock : IPhoneMock
    {
        private readonly IBrandMock _brandMock = new BrandMock();

        public IEnumerable<Phone> Phones => new List<Phone>()
        {
            new Phone
            {
                PhoneNaming = "IPhone 13",
                PhoneBrand =  _brandMock.PhoneBrands.First(),
                Price = 1,
                MainCamera = 24,
                RAM = 8,
                OperatingSystem = Enumerations.OperatingSystem.IOS,
                ScreenType = Enumerations.ScreenType.Retina,
                Color = "Pink",
                Storage = "1TB",
                ImageUrl = "https://cdn.comfy.ua/media/catalog/product/cache/4/small_image/270x265/62defc7f46f3fbfc8afcd112227d1181/i/p/iphone_13_q421_pink_pdp_image_position-1a__ww-ru_1.jpg"
            },

            new Phone
            {
                PhoneNaming = "Xiaomi Mi 11",
                PhoneBrand =  _brandMock.PhoneBrands.Last(),
                Price = 8000,
                MainCamera = 24,
                RAM = 8,
                OperatingSystem = Enumerations.OperatingSystem.Android,
                ScreenType = Enumerations.ScreenType.Amoled,
                ImageUrl = "https://cdn.comfy.ua/media/catalog/product/cache/4/small_image/270x265/62defc7f46f3fbfc8afcd112227d1181/n/o/note_11_pro_black_4.jpg",
                Color = "Black",
                Storage = "256 GB",
            },

            new Phone
            {
                PhoneNaming = "Miaomi 10C",
                PhoneBrand =  _brandMock.PhoneBrands.Last(),
                Price = 8000,
                MainCamera = 24,
                RAM = 8,
                Color = "Black",
                Storage = "256 GB",
                OperatingSystem = Enumerations.OperatingSystem.Android,
                ScreenType = Enumerations.ScreenType.Amoled,
                ImageUrl = "https://i.allo.ua/media/catalog/product/cache/1/image/524x494/602f0fa2c1f0d1ba5e241f914e856ff9/l/d/ld0005946049_1.jpg"
            },

            new Phone
            {
                PhoneNaming = "Xiaomi Mi 9",
                PhoneBrand =  _brandMock.PhoneBrands.Last(),
                Price = 8000,
                MainCamera = 24,
                RAM = 8,
                Color = "Purple",
                Storage = "256 GB",
                OperatingSystem = Enumerations.OperatingSystem.Android,
                ScreenType = Enumerations.ScreenType.Amoled,
                ImageUrl = "https://i.allo.ua/media/catalog/product/cache/1/image/524x494/602f0fa2c1f0d1ba5e241f914e856ff9/l/d/ld0005946049_1.jpg"
            },

            new Phone
            {
                PhoneNaming = "Xiaomi Mi 9",
                PhoneBrand =  _brandMock.PhoneBrands.Last(),
                Price = 8000,
                MainCamera = 24,
                RAM = 8,
                Color = "Purple",
                Storage = "256 GB",
                OperatingSystem = Enumerations.OperatingSystem.Android,
                ScreenType = Enumerations.ScreenType.Amoled,
                ImageUrl = "https://i.allo.ua/media/catalog/product/cache/1/image/524x494/602f0fa2c1f0d1ba5e241f914e856ff9/l/d/ld0005946049_1.jpg"
            },

            new Phone
            {
                PhoneNaming = "Miaomi Mi 9",
                PhoneBrand =  _brandMock.PhoneBrands.Last(),
                Price = 8000,
                MainCamera = 24,
                RAM = 8,
                OperatingSystem = Enumerations.OperatingSystem.Android,
                ScreenType = Enumerations.ScreenType.Amoled,
                Color = "Purple",
                Storage = "256 GB",
                ImageUrl = "https://i.allo.ua/media/catalog/product/cache/1/image/524x494/602f0fa2c1f0d1ba5e241f914e856ff9/l/d/ld0005946049_1.jpg"
            }
        };
    }
}
