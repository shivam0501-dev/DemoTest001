using DemoTest001.DataAccess.Entity;
using DemoTest001.Models;

namespace DemoTest001.DataAccess.Repository.IRepository
{
    public interface ICountryRepository
    {
        Task<Status> AddCountryAsync(Country country);
        Task<List<Country>> GetCountriesAsync();
        Task<Status> DeleteCountryAsync(int id);
        Task<Country> EditCountryAsync(int id);
        Task<Status> UpdateCountryAsync(Country country);
    }
}
