using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Jtfer.Ecp.Legacy.DataAccess
{
    [DataContract]
    public abstract class DbObjectLegacy
    {
        [DataMember]
        public virtual int Id { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }

        public DbObjectLegacy()
        {
            CreateDate = DateTime.Now;
        }
    }
}
