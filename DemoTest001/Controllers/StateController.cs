using DemoTest001.DataAccess.Entity;
using DemoTest001.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DemoTest001.Controllers
{
    public class StateController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;
        public StateController(ICountryRepository countryRepository, IStateRepository stateRepository)
        {
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
        }
        public IActionResult State()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateState(State StateData)
        {
            if (StateData.StateId > 0)
            {
                var updateState = await _stateRepository.UpdateStatesync(StateData);
                return Json(updateState);
            }
            else
            {
                var AddState = await _stateRepository.AddStateAsync(StateData);
                return Json(AddState);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllState()
        {
            var state = await _stateRepository.GetStateAsync();
            return Json(new { data = state });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteState(int Id)
        {
            var state = await _stateRepository.DeleteStateAsync(Id);
            return Json(state);
        }
        [HttpPost]
        public async Task<IActionResult> EditState(int Id)
        {
            var state = await _stateRepository.EditStateAsync(Id);
            return Json(state);
        }
        [HttpGet]
        public async Task<IActionResult> BindCountry()
        {
            var countries = await _countryRepository.GetCountriesAsync();
            return Json(countries);
        }
    }
}
