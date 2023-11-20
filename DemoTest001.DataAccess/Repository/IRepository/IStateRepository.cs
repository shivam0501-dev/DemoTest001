using DemoTest001.DataAccess.Entity;
using DemoTest001.Models;

namespace DemoTest001.DataAccess.Repository.IRepository
{
    public interface IStateRepository
    {
        Task<Status> AddStateAsync(State state);
        Task<List<State>> GetStateAsync();
        Task<Status> DeleteStateAsync(int id);
        Task<State> EditStateAsync(int id);
        Task<Status> UpdateStatesync(State State);
    }
}
