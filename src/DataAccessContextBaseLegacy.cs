using System;
using System.Collections.Generic;
using System.Text;

namespace Jtfer.Ecp.Legacy.DataAccess
{
    public abstract class DataAccessContextBaseLegacy : PipelineContext
    {
        public DataAccessContextBaseLegacy(Domain domain, bool isActive = true, string name = null) : base(domain, isActive, name)
        {
        }

        protected override void AddContainers()
        {
            AddContainer<DataMemoryProviderLegacy>();
            var dbRouter = AddContainer<DbRouterLegacy>();
            AddContainer<DataGatewayLegacy>();
            var providers = DefineDbConnections();
            dbRouter.SetProviders(providers);
        }

        public abstract IEnumerable<DbConnectionBaseLegacy> DefineDbConnections();

        protected override void AddOperations(Pipeline pipeline)
        {
        }

    }
}
