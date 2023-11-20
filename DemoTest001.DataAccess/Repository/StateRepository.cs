using DemoTest001.DataAccess.DataContext;
using DemoTest001.DataAccess.Entity;
using DemoTest001.DataAccess.Repository.IRepository;
using DemoTest001.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoTest001.DataAccess.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationContext _db;
        public StateRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Status> AddStateAsync(State state)
        {
            Status status = new Status();
            try
            {
                await _db.states.AddAsync(state);
                _db.SaveChanges();
                status.StatusMessage = "State Added Successfully";
                status.StatusCode = "1";
            }
            catch (Exception ex)
            {
                status.StatusMessage = "Something Wrong" + ex.Message;
                status.StatusCode = "0";
            }
            return status;
        }
        public async Task<List<State>> GetStateAsync()
        {
            List<State> states = await _db.states.Include(s => s.country).ToListAsync();
            return states;
        }

        public async Task<Status> DeleteStateAsync(int id)
        {
            Status status = new Status();
            try
            {
                var findState = await _db.states.FindAsync(id);
                if (findState != null)
                {
                    _db.states.Remove(findState);
                    await _db.SaveChangesAsync();
                    status.StatusMessage = "State Deleted Successfully!!";
                    status.StatusCode = "1";
                }
            }
            catch (Exception ex)
            {
                status.StatusMessage = "Something Wrong!!" + ex.Message;
                status.StatusCode = "0";
            }
            return status;
        }

        public async Task<State> EditStateAsync(int id)
        {
            var findState = await _db.states.FindAsync(id);
            if (findState != null)
                return findState;
            else
            {
                State State = new State();
                return State;
            }
        }
        public async Task<Status> UpdateStatesync(State State)
        {
            Status status = new Status();
            var findState = await _db.states.FindAsync(State.StateId);
            if (findState != null)
            {

                findState.StateCode = State.StateCode;
                findState.StateName = State.StateName;
                findState.CountryID = State.CountryID;
                _db.states.Update(findState);
                await _db.SaveChangesAsync();
                status.StatusMessage = "State Updated Successfully";
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
