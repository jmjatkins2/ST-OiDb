using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInstruments.ApiProxy
{
    public class Auth0Configuration
    {
        public string Domain { get; set; }
        public string ClientID { get; set; }
        public string Connection { get; set; }
        public string Scope { get; set; }
    }
}
