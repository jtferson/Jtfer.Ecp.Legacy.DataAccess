using System;
using System.Collections.Generic;
using System.Text;

namespace Jtfer.Ecp.Legacy.DataAccess
{
 
    public class DbSetLegacy<T>
      where T : DbObjectLegacy, new()
    {
        public DbSetLegacy(DbConnectionBaseLegacy provider)
        {
            provider.MapEntityToTable<T>();
        }
    }
    public abstract class DbContextBaseLegacy<T> : IContainer
        where T : DbConnectionBaseLegacy
    {
        protected T _ = null;

        public void Initialize()
        {
            DefineDbContext();
        }

        protected abstract void DefineDbContext();
    }
}
