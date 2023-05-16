using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PhoneStoreApplication.Data.Repository;
using PhoneStoreApplication.MocksData;
using PhoneStoreApplication.Models;

namespace PhoneStoreApplication.Data
{
    public static class DataInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<ApplicationContext>();
            
            // Check database exiting
            var isExists = context!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator
                           && await databaseCreator.ExistsAsync();

            // Automatically migrate
            await context!.Database.MigrateAsync();

            // When we run first time then populate database by Initial Values
            if (!isExists)
            {
                var phoneRepository = scope.ServiceProvider.GetService<IGenericRepository<Phone>>();
                var phoneMock = scope.ServiceProvider.GetService<IPhoneMock>();

                // Add Phones from Mock
                foreach(var phone in phoneMock.Phones)
                {
                    await phoneRepository.AddAsync(phone);
                }
            }
        }
    }
}
