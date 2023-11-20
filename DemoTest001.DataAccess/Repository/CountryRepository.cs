using DemoTest001.DataAccess.DataContext;
using DemoTest001.DataAccess.Entity;
using DemoTest001.DataAccess.Repository.IRepository;
using DemoTest001.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DemoTest001.DataAccess.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationContext _db;
        public CountryRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Status> AddCountryAsync(Country country)
        {
            Status status = new Status();
            try
            {
                await _db.countries.AddAsync(country);
                _db.SaveChanges();
                status.StatusMessage = "Country Added Successfully";
                status.StatusCode = "1";
            }
            catch (Exception ex)
            {
                status.StatusMessage = "Something Wrong" + ex.Message;
                status.StatusCode = "0";
            }
            return status;
        }
        public async Task<List<Country>> GetCountriesAsync()
        {
            List<Country> countries = await _db.countries.ToListAsync();
            return countries;
        }

        public async Task<Status> DeleteCountryAsync(int id)
        {
            Status status = new Status();
            try
            {
                var findCountry=await _db.countries.FindAsync(id);
                if(findCountry!=null)
                {
                     _db.countries.Remove(findCountry);   
                   await _db.SaveChangesAsync();
                    status.StatusMessage = "Country Deleted Successfully!!";
                    status.StatusCode = "1";
                }
            }
            catch (Exception ex)
            {
                status.StatusMessage = "Something Wrong!!"+ex.Message;
                status.StatusCode = "0";
            }
            return status;
        }

        public async Task<Country> EditCountryAsync(int id)
        {
                var findCountry = await _db.countries.FindAsync(id);
               if (findCountry!=null)
                return findCountry;
            else
            {
                Country country = new Country();
                return country;
            }
        }
        public async Task<Status> UpdateCountryAsync(Country country)
        {
            Status status = new Status();
            var findCountry = await _db.countries.FindAsync(country.CountryId);
            if (findCountry != null)
            {

                findCountry.CountryCode = country.CountryCode;
                findCountry.CountryName = country.CountryName;
                _db.countries.Update(findCountry);
                await _db.SaveChangesAsync();
                status.StatusMessage = "Country Updated Successfully";
                status.StatusCode = "1";
            }
            else
            {
                status.StatusMessage = "Something Wrong Country Not Found";
                status.StatusCode = "0";
            }
            return status;  
        }
    }
}
