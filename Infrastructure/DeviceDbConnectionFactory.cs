using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DeviceDbConnectionFactory : AbstractDbConnectionFactory
    {
        protected override string ConnectionStringName
        {
            get { return "ConnectionStringDEVICE"; }
        }
    }
}
