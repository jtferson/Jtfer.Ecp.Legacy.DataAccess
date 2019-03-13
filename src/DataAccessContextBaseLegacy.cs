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

        }

        public void DefineDbRouter()
        {

        }

    }
}
