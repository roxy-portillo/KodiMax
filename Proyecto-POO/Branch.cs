using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO
{
    class Branch
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Branch(string id, string name, string type)
        {
            ID = id;
            Name = name;
            Type = type;
        }

        public Branch()
        {

        }

        public override string ToString()
        {
            return string.Format("{0}\t{1} {2}\n", ID, Type, Name);
        }
    }
}
