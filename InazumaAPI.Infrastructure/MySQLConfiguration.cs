using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Infrastructure
{
    public class MySQLConfiguration
    {

        public MySQLConfiguration(string connstring) 
        { 
            Connstring = connstring;
        }

        public string Connstring;
    }
}
