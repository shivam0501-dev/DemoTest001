using DemoTest001.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest001.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
         ICountryRepository countryRepository { get;}
         IStateRepository stateRepository { get;}
    }
}
