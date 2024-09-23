using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftetherAnalyze.DATA_Structure
{
    internal class root
    { 
        private Dictionary<string, Vhubs> data_VHubs = new Dictionary<string, Vhubs>();

        public bool vhubadd(string name) 
        {
            bool status;

            if (!data_VHubs.ContainsKey(name)) 
            {
                Vhubs vhub = new Vhubs(name);

                data_VHubs.Add(name, vhub);

                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

    }


   


}
