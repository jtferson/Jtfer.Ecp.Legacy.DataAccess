using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Jtfer.Ecp.Legacy.DataAccess
{
    public abstract class DbConnectionBaseLegacy : IContainer
    {
        private Queue<Action> _transactions = new Queue<Action>();
        protected abstract string DatabaseName { get; }
        protected string DbPath { get; private set; }

        public void Initialize(string dbVersion)
        {
            DbPath = GetDbPath(dbVersion);
        }

        public void ExecuteTransactions()
        {
            var transactions = _transactions.ToArray();
            if (transactions.Any())
            {
                RunInTransaction((Action)Delegate.Combine(transactions));
                _transactions.Clear();
            }
        }
        public void AddTransaction(Action transaction)
        {
            _transactions.Enqueue(transaction);
        }

        protected abstract string GetDbPath(string dbVersion);

        public abstract IEnumerable<T> Get<T>() where T : DbObjectLegacy;
        public abstract IEnumerable<T> Get<T>(Expression<Func<T, bool>> query) where T : DbObjectLegacy;
        public abstract void Insert<T>(T dto) where T : DbObjectLegacy;
        public abstract void Update<T>(IEnumerable<T> dtos) where T : DbObjectLegacy;
        public abstract bool Update<T>(T dto) where T : DbObjectLegacy;
        public abstract bool Upsert<T>(T dto) where T : DbObjectLegacy;
        public abstract bool Delete<T>(int id) where T : DbObjectLegacy;
        public abstract void DeleteAll<T>() where T : DbObjectLegacy;
        public abstract void RunInTransaction(Action transaction);
        public abstract IEnumerable<Type> GetMappedTypes();
        public abstract void MapEntityToTable<T>() where T : DbObjectLegacy;

    }
}
