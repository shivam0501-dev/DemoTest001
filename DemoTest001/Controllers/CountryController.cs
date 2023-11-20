using DemoTest001.DataAccess.Entity;
using DemoTest001.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DemoTest001.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IActionResult Country()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCountry(Country countryData)
        {
            if (countryData.CountryId > 0)
            {
                var updateCountry = await _countryRepository.UpdateCountryAsync(countryData);
                return Json(updateCountry);
            }
            else
            {
                var AddCountry = await _countryRepository.AddCountryAsync(countryData);
                return Json(AddCountry);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCountry()
        {
            var country = await _countryRepository.GetCountriesAsync();
            return Json(new { data = country });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCountry(int Id)
        {
            var country = await _countryRepository.DeleteCountryAsync(Id);
            return Json(country);
        }
        [HttpPost]
        public async Task<IActionResult> EditCountry(int Id)
        {
            var country = await _countryRepository.EditCountryAsync(Id);
            return Json(country);
        }
    }
}
