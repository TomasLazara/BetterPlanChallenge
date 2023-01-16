using _BLL.Repository;
using BetterPlanChallenge.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork

    {
        private IRepository<User> _users;
        private IRepository<Goal> _goals;

        private IDBORepository _dbo;
        private DbContext _ctx;
        public UnitOfWork(DbContext ctx)
        {
            _ctx= ctx;
        }
        public IRepository<User> Users
        {
            get {
                return _users == null ?
                       _users = new Repository<User>(_ctx) :
                       _users;
            }            
        }

        public IRepository<Goal> Goals
        {
            get
            {
                return _goals == null ?
                       _goals = new Repository<Goal>(_ctx) :
                       _goals;
            }
        }

        public IDBORepository Dbo { 
            get {
                return _dbo == null ?
                    _dbo = new DBOperationsRepository(_ctx) :
                    _dbo;
            }         
        }

        public async Task Save()
        {
            _ = await _ctx.SaveChangesAsync();    
        }
    }
}
