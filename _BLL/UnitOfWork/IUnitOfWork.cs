using _BLL.Repository;
using BetterPlanChallenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IDBORepository Dbo { get; }
        Task Save();
    }
}
