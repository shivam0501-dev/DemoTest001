using DemoTest001.DataAccess.DataContext;
using DemoTest001.DataAccess.Repository;
using DemoTest001.DataAccess.Repository.IRepository;

namespace DemoTest001.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;

        public UnitOfWork(ApplicationContext db, ICountryRepository countryRepository, IStateRepository stateRepository)
        {
            _db = db;
            this.countryRepository = countryRepository;
            this.stateRepository = stateRepository;
        }

        public ICountryRepository countryRepository { get; private set; }
        public IStateRepository stateRepository { get; private set; }
    }
}
