using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO
{
    class ManageBranches : Branch
    {
        public List<Branch> Branches = new List<Branch>();

        public void BranchList()
        {
            Branch branch1 = new Branch("KM01", "KodiMax Centro", "Salas de Cine");
            Branches.Add(branch1);
            Branch branch2 = new Branch("KM0101", "KodiMax Centro", "Autocine");
            Branches.Add(branch2);
            Branch branch3 = new Branch("KM02", "KodiMax Sur", "Salas de Cine");
            Branches.Add(branch3);
            Branch branch4 = new Branch("KM0201", "KodiMax Sur", "Autocine");
            Branches.Add(branch4);
        }

        public void Print()
        {
            Console.Clear();
            if (Branches.Count == 0)
            {
                BranchList();
            }
            Console.WriteLine("\tNuevas Sucursales\n---------------------------------------------\n");
            foreach (Branch b in Branches)
            {
                if (b != null)
                {
                    Console.WriteLine(b);
                }
            }
        }
    }
}

